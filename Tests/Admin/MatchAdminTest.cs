using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Super_Cartes_Infinies.Areas.Admin;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Match = Super_Cartes_Infinies.Models.Match;

namespace Tests.Admin
{
    [TestClass]
    public class MatchesAdminControllerTests
    {
        DbContextOptions<ApplicationDbContext> options;
        public MatchesAdminControllerTests()
        { 
        //  On initialise les options de la BD, on utilise une InMemoryDatabase
        options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "CardsService")
                .Options;
        }

    [TestMethod]
        public async Task Index_ReturnsViewWithMatches()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Matches.Add(new Match
                {
                    Id = 1,
                    UserAId = "UserAId",
                    UserBId = "UserBId",
                });
                dbContext.SaveChanges();

                var controller = new MatchesController(dbContext);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = result as ViewResult;
                Assert.IsNotNull(viewResult);
                var model = viewResult.Model as IEnumerable<Match>;
                Assert.IsNotNull(model);
                Assert.AreEqual(1, model.Count()); // Assurez-vous qu'il y a au moins un match dans le modèle.
            }
        }

        [TestMethod]
        public async Task Index_ReturnsBadRequestForNullMatches()
        {
            // Arrange
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Matches = null; // Simulez un DbSet<Match> null
                var controller = new MatchesController(dbContext);

                // Act
                var result = await controller.Index();

                // Assert
                Assert.IsInstanceOfType(result, typeof(ObjectResult));
                var objectResult = (ObjectResult)result;

                // Assert that the ObjectResult contains a ProblemDetails
                Assert.IsInstanceOfType(objectResult.Value, typeof(ProblemDetails));
                var problemDetails = (ProblemDetails)objectResult.Value;

                // Assert the error message
                string expectedErrorMessage = "Entity set 'ApplicationDbContext.Matches'  is null.";
                Assert.AreEqual(expectedErrorMessage.ToLower(), problemDetails.Detail.ToLower());
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsBadRequestForNullMatches()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                // Arrange
                dbContext.Matches = null; // Simulate a null DbSet<Match>
                var controller = new MatchesController(dbContext);

                // Act
                var result = await controller.Delete(1);

                // Assert
                Assert.IsInstanceOfType(result, typeof(ObjectResult)); // Vérifiez le type ObjectResult
                var objectResult = (ObjectResult)result;
                Assert.IsInstanceOfType(objectResult.Value, typeof(ProblemDetails)); // Vérifiez que la valeur est un ProblemDetails
                var problemDetails = (ProblemDetails)objectResult.Value;

                string expectedErrorMessage = "Entity set 'ApplicationDbContext.Matches'  is null.";
                string actualErrorMessage = problemDetails.Detail;

                Assert.AreEqual(expectedErrorMessage.ToLower(), actualErrorMessage.ToLower());
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFoundForNonExistentMatch()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new MatchesController(dbContext);

                // Act
                var result = await controller.Delete(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }

    }

}