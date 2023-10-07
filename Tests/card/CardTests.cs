using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Super_Cartes_Infinies.Areas.Admin;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestClass]
    public class CardsControllerTests
    {
        
        DbContextOptions<ApplicationDbContext> options;
        public CardsControllerTests()
        {
            //  On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "CardsService")
                .Options;
        }
        [TestInitialize]
        public void Init()
        {
            //  avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(options);
            //  on ajoute des données de tests
            db.AddRange(SeedTest.SeedCards());
            db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            // on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.SaveChanges();
        }

        [TestMethod]
        public void Index_ReturnsViewWithCards()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);

                // Act
                var result = controller.Index().Result as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model as List<Card>);
                Assert.AreEqual(14, (result.Model as List<Card>).Count); // if you ad card then 14 beconme new num of cards
            }
        }

        [TestMethod]
        public void Details_ReturnsViewWithValidId()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                int validId = 1;

                // Act
                var result = controller.Details(validId).Result as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model as Card);
                Assert.AreEqual(validId, (result.Model as Card).Id);
            }
        }

        [TestMethod]
        public void Details_ReturnsNotFoundWithInvalidId()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                int invalidId = 999;

                // Act
                var result = controller.Details(invalidId).Result;

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }
        [TestMethod]
        public void Details_ReturnsNotFoundWithNoSeed()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                 context.Cards = null;
                var controller = new CardsController(context);
                // Act
                var result = controller.Details(2).Result;

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        }
        //[TestMethod]
        //public void Create_ReturnsView()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {

        //        var controller = new CardsController(context);

        //        // Act
        //        var result = controller.Create() as ViewResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //    }
        //}
        [TestMethod]
        public void Create_Post_ValidCard()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                var card = new Card
                {
                    Id = 15, // Ensure a unique ID
                    Name = "New Card",
                    Attack = 20,
                    Defense = 10,
                    ImageUrl = "newimage.jpg"
                };

                // Act
                var result = controller.Create(card).Result as RedirectToActionResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.ActionName); // Check if it redirects to the Index action
                Assert.AreEqual(15, context.Cards.Count()); // Ensure the card was added to the database
            }
        }

        [TestMethod]
        public void Create_Post_InvalidCard()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                var card = new Card(); // Invalid card with missing properties

                // Add model validation error to ModelState to simulate ModelState.IsValid = false
                controller.ModelState.AddModelError("Name", "The Name field is required.");

                // Act
                var result = controller.Create(card).Result as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(card, result.Model); // Check if the model being returned is the same as the one we passed in
                Assert.AreEqual(14, context.Cards.Count()); // Ensure no new card was added to the database
            }
        }
        //[TestMethod]
        //public void Edit_ReturnsViewWithValidId()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int validId = 1;

        //        // Act
        //        var result = controller.Edit(validId).Result as ViewResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.IsNotNull(result.Model as Card);
        //        Assert.AreEqual(validId, (result.Model as Card).Id);
        //    }
        //}

        //[TestMethod]
        //public void Edit_ReturnsNotFoundWithInvalidId()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int invalidId = 999;

        //        // Act
        //        var result = controller.Edit(invalidId).Result;

        //        // Assert
        //        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //    }
        //}

        //[TestMethod]
        //public void Edit_ReturnsNotFoundWithNoSeed()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        context.Cards = null;
        //        var controller = new CardsController(context);
        //        int validId = 2; // A valid ID that would exist if there were data

        //        // Act
        //        var result = controller.Edit(validId).Result;

        //        // Assert
        //        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //    }
        //}
        //[TestMethod]
        //public async Task Edit_Post_ValidCard()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int validId = 1; // A valid ID from your test data
        //        var updatedCard = new Card
        //        {
        //            Id = validId,
        //            Name = "Updated Card",
        //            Attack = 25,
        //            Defense = 12,
        //            ImageUrl = "updatedimage.jpg"
        //        };

        //        // Act
        //        var result = await controller.Edit(validId, updatedCard) as RedirectToActionResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual("Index", result.ActionName); // Check if it redirects to the Index action
        //        var cardInDb = await context.Cards.FindAsync(validId);
        //        Assert.AreEqual(updatedCard.Name, cardInDb.Name); // Check if the card was updated in the database
        //    }
        //}

        //[TestMethod]
        //public async Task Edit_Post_InvalidModelState()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int validId = 1; // A valid ID from your test data
        //        var updatedCard = new Card
        //        {
        //            Id = validId,
        //            Name = "Updated Card",
        //            Attack = 25,
        //            Defense = 12,
        //            ImageUrl = "updatedimage.jpg"
        //        };

        //        // Add model validation error to ModelState to simulate ModelState.IsValid = false
        //        controller.ModelState.AddModelError("Name", "The Name field is required.");

        //        // Act
        //        var result = await controller.Edit(validId, updatedCard) as ViewResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(updatedCard, result.Model); // Check if the model being returned is the same as the one we passed in
        //        var cardInDb = await context.Cards.FindAsync(validId);
        //        Assert.AreNotEqual(updatedCard.Name, cardInDb.Name); // Check if the card was not updated in the database
        //    }
        //}

        //[TestMethod]
        //public async Task Edit_Post_InvalidCardId()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int validId = 1; // A valid ID from your test data
        //        int invalidId = 999; // An invalid ID
        //        var updatedCard = new Card
        //        {
        //            Id = validId,
        //            Name = "Updated Card",
        //            Attack = 25,
        //            Defense = 12,
        //            ImageUrl = "updatedimage.jpg"
        //        };

        //        // Act
        //        var result = await controller.Edit(invalidId, updatedCard) as NotFoundResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        var cardInDb = await context.Cards.FindAsync(validId);
        //        Assert.AreNotEqual(updatedCard.Name, cardInDb.Name); // Check if the card was not updated in the database
        //    }
        //}
        private bool CardExists(int id)
        {
            var context = new ApplicationDbContext(options);
            return (context.Cards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [TestMethod]
        public async Task Delete_ReturnsViewWithValidId()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                int validId = 1; // A valid ID from your test data

                // Act
                var result = await controller.Delete(validId) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model as Card);
                Assert.AreEqual(validId, (result.Model as Card).Id);
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFoundWithInvalidId()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new CardsController(context);
                int invalidId = 999; // An invalid ID

                // Act
                var result = await controller.Delete(invalidId) as NotFoundResult;

                // Assert
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFoundWithNoSeed()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                context.Cards = null;
                var controller = new CardsController(context);
                int validId = 2; // A valid ID that would exist if there were data

                // Act
                var result = await controller.Delete(validId) as NotFoundResult;

                // Assert
                Assert.IsNotNull(result);
            }
        }
        //[TestMethod]
        //public async Task DeleteConfirmed_RemovesCardWithValidId()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var controller = new CardsController(context);
        //        int validId = 1; // A valid ID from your test data

        //        // Act
        //        var result = await controller.DeleteConfirmed(validId) as RedirectToActionResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual("Index", result.ActionName); // Check if it redirects to the Index action
        //        var cardInDb = await context.Cards.FindAsync(validId);
        //        Assert.IsNull(cardInDb); // Check if the card was removed from the database
        //    }
        //}

        //[TestMethod]
        //public async Task DeleteConfirmed_ReturnsProblemWithNoContextCards()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        context.Cards = null;
        //        var controller = new CardsController(context);
        //        int validId = 1; // A valid ID from your test data

        //        // Act
        //        var result = await controller.DeleteConfirmed(validId) as ObjectResult;

        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(500, result.StatusCode); // Check if it returns a 500 status code for a problem
        //    }
        //}
        
        // Ajoutez des méthodes de test similaires pour les autres actions du contrôleur (Create, Edit, Delete).
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    [TestClass]
    public class CardsServiceTests
    {
        // Mettre seulement les optionms ici et non la BD en entier
        // La BD doit être crée et détruite pour chacun des tests, sinon il y aura des problèmes avec le tracking des éléments
        DbContextOptions<ApplicationDbContext> options;
        public CardsServiceTests()
        {
            //  On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                //  il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "CardsService")
                .Options;
        }
        [TestInitialize]
        public void Init()
        {
            //  avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(options);
            //  on ajoute des données de tests
            db.AddRange(SeedTest.SeedCards());
            db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            // on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.SaveChanges();
        }
        [TestMethod]
        public async Task AddValidCardAsync()
        {
            // Test classique d'une méthode de service
            using ApplicationDbContext db = new ApplicationDbContext(options);
            CardService service = new CardService(db);

            var c  = await service.getallcards();
            Assert.AreEqual( c.Value.Count(),  db.Cards.Count());
        }
    }
}

