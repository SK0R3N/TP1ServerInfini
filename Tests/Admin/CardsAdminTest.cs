using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Areas.Admin;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;


namespace Tests.Admin
{
    [TestClass]
    public class CardsAdminControllerTests
    {

        DbContextOptions<ApplicationDbContext> options;
        public CardsAdminControllerTests()
        {
            //  On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "CardsService")
                .Options;
        }

        [TestMethod]
        public async Task Index_ReturnsViewWithCards()
        {
            // Arrange
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(new Card { /* Ajoutez une carte pour le test */ });
                dbContext.SaveChanges();

                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = result as ViewResult;
                Assert.IsNotNull(viewResult);
                var model = viewResult.Model as IEnumerable<Card>;
                Assert.IsNotNull(model);
                Assert.AreEqual(1, model.Count()); // Assurez-vous qu'il y a au moins une carte dans le modèle.
            }
        }

        [TestMethod]
        public async Task Details_ReturnsNotFoundForNullId()
        {
            // Arrange
            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Details(null);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }


        [TestMethod]
        public async Task Details_ReturnsNotFoundForNonExistentId()
        {
            // Arrange

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Details(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task StartedCard_ReturnsNotFoundForNullId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.StartedCard(null);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task StartedCard_ReturnsNotFoundForNonExistentId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.StartedCard(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task StartedCard_TogglesCarteDepartAndSavesChanges()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId, CarteDepart = false };



            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.StartedCard(cardId);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
                Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);

                var updatedCard = dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
                Assert.IsNotNull(updatedCard);
                Assert.IsTrue(updatedCard.CarteDepart);
            }
        }

        [TestMethod]
        public async Task Create_AddsCardAndRedirectsToIndexForValidModelState()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureCreated();

                var controller = new CardsController(dbContext);
                var card = new Card { Id = 1, Name = "Test Card" };

                // Act
                var result = await controller.Create(card);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
                var redirectResult = (RedirectToActionResult)result;
                Assert.AreEqual("Index", redirectResult.ActionName);
            }

        }
        [TestMethod]
        public async Task Edit_ReturnsNotFoundForNullId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(null);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task Edit_ReturnsNotFoundForNonExistentId()
        {
            // Arrange

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task Edit_ReturnsViewWithCardForValidId()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };

            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(cardId);

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.IsNotNull(viewResult.ViewData.Model);
                Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Card));
            }
        }

        [TestMethod]
        public async Task Edit_ReturnsNotFoundForInvalidId()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };



            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task EditPost_ReturnsNotFoundForNonMatchingId()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(999, card);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task EditPost_ReturnsViewForInvalidModelState()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };


            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);
                controller.ModelState.AddModelError("Name", "Name is required.");

                // Act
                var result = await controller.Edit(cardId, card);

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.IsNotNull(viewResult.ViewData.Model);
                Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Card));
            }
        }

        [TestMethod]
        public async Task EditPost_UpdatesCardAndRedirectsToIndexForValidModelState()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };



            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Edit(cardId, card);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
                var redirectResult = (RedirectToActionResult)result;
                Assert.AreEqual("Index", redirectResult.ActionName);

                var updatedCard = dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
                Assert.IsNotNull(updatedCard);
                // Vous pouvez ajouter d'autres assertions pour vérifier que la carte a été mise à jour correctement.
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFoundForNullId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Delete(null);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFoundForNonExistentId()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Delete(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsViewWithCardForValidId()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };


            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.Delete(cardId);

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.IsNotNull(viewResult.ViewData.Model);
                Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(Card));
            }
        }

        [TestMethod]
        public async Task DeleteConfirmed_ReturnsNotFoundForNonExistingCard()
        {
            // Arrange

            using (var dbContext = new ApplicationDbContext(options))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.DeleteConfirmed(999); // ID qui n'existe pas

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }

        [TestMethod]
        public async Task DeleteConfirmed_RemovesCardAndRedirectsToIndexForValidId()
        {
            // Arrange
            var cardId = 1;
            var card = new Card { Id = cardId };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cards.Add(card);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CardsController(dbContext);

                // Act
                var result = await controller.DeleteConfirmed(cardId);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
                var redirectResult = (RedirectToActionResult)result;
                Assert.AreEqual("Index", redirectResult.ActionName);

                var deletedCard = dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
                Assert.IsNull(deletedCard);
            }
        }
    }
}
