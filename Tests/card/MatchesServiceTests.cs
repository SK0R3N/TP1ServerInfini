
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System.Collections.Generic;
using Tests;
using Super_Cartes_Infinies.Services.Interfaces;

namespace Super_Cartes_InfiniesTests.Services
{
    [TestClass]
    public class MatchesServiceTests
    {
        DbContextOptions<ApplicationDbContext> options;
        public MatchesServiceTests()
        {
            //  On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "EventServiceTest")
                .Options;

        }
        [TestInitialize]
        public void Init()
        {
            //  avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(options);

            // Add test data
            var chek = options;


            var cards = SeedTest.SeedCards(); // Generate the array of cards

            foreach (var card in cards)
            {
                db.Cards.Add(card); // Add each card to the database
            }
            db.SaveChanges();
            var players = SeedTest.SeedPlayers(cards.ToList()); // Generate players using the cards list
            foreach (var player in players)
            {
                db.Players.Add(player); // Add each player to the database
            }
            

            db.SaveChanges();
            int jn = 4;

        }
        [TestCleanup]
        public void Dispose()
        {
            // on efface les données de tests pour remettre la BD dans options état initial
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Cards.RemoveRange(db.Cards);
            db.Players.RemoveRange(db.Players);
            db.SaveChanges();
        }


        //  On test la méthode PlayCard


        [TestMethod]
        public async Task PlayCard_ThrowsException_WhenCardNotFound()
        {
            using (var context = new ApplicationDbContext(options))
            {
                // Arrange
                MatchesService Service = new MatchesService(context);

                // Act & Assert
                await Assert.ThrowsExceptionAsync<Exception>(() => Service.PlayCard("userA", 1, 999));
            }
        }

        [TestMethod]
        public async Task PlayCard_ThrowsException_WhenUserNotInMatch()
        {
            using (var context = new ApplicationDbContext(options))
            {
                // Arrange
                MatchesService Service = new MatchesService(context);

                // Assuming you have seeded a match and card in your test database

                // Act & Assert
                await Assert.ThrowsExceptionAsync<Exception>(() => Service.PlayCard("userC", 1, 1));
            }
        }
        //  On test l'event PlayCardEvent qui est créé par la méthode PlayCard
        [TestMethod]
        public async Task PlayCardEvent_Constructor_ShouldAddCardToBattleFieldAsync()
        {
            // Arrange
            using (var context = new ApplicationDbContext(options))
            {
                var playerA = context.Players.FirstOrDefault(p => p.Name == "ShadowStrike");
                var playerB = context.Players.FirstOrDefault(p => p.Name == "DragonSlayer");
                MatchesService Service = new MatchesService(context);
                var match = new Match
                {
                    IsMatchCompleted = false,
                IsPlayerATurn = true,
                    EventIndex = 0,
                    WinnerUserId = null,
                    UserAId = playerA.Id.ToString(),
                    UserBId = playerB.Id.ToString(),




                    PlayerDataA = new MatchPlayerData { PlayerId = playerA.Id },
                    PlayerDataB = new MatchPlayerData { PlayerId = playerB.Id },
                    SerializedEvents = new List<SerializedMatchEvent>() //empty for now
                    
                };
                // Check if playerA.Cartes is null
                if (playerA.Cartes != null)
                {
                    // Set the CardsPile for playerA
                    match.PlayerDataA.CardsPile = new List<PlayableCard>((IEnumerable<PlayableCard>)playerA.Cartes);
                }
                else
                {
                    Assert.Fail("PlayerA's Cartes is null.");
                }
                match.PlayerDataB.CardsPile = new List<PlayableCard>((IEnumerable<PlayableCard>)playerB.Cartes);

                context.Matches.Add(match);
                context.SaveChanges();
                 await  Service.StartMatch( playerA.Id.ToString(), match.Id);
                await Service.StartMatch(playerB.Id.ToString(), match.Id);

                var playableCardId = 1; // Assume this card ID exists in the database

                // Act
                var playCardEvent = new PlayCardEvent(match, match.PlayerDataA, match.PlayerDataB, playableCardId);

                // Assert
                Assert.AreEqual(playableCardId, playCardEvent.PlayableCardId);
                Assert.AreEqual(match.PlayerDataA.PlayerId, playCardEvent.PlayerId);
                Assert.AreEqual(0, match.PlayerDataA.Hand.Count); // Card should be removed from hand
                Assert.AreEqual(1, match.PlayerDataA.BattleField.Count); // Card should be added to the battlefield
            }
        }

        //[TestMethod]
        //public void PlayCardEvent_Constructor_ShouldAddPlayerTurnEvent()
        //{
        //    // Arrangeuv
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var playerA = context.Players.FirstOrDefault(p => p.Name == "PlayerA");
        //        var playerB = context.Players.FirstOrDefault(p => p.Name == "PlayerB");

        //        var match = new Match
        //        {
        //            PlayerDataA = new MatchPlayerData { PlayerId = playerA.Id },
        //            PlayerDataB = new MatchPlayerData { PlayerId = playerB.Id }
        //        };
        //        context.Matches.Add(match);
        //        context.SaveChanges();

        //        var playableCardId = 1; // Assume this card ID exists in the database

        //        // Act
        //        var playCardEvent = new PlayCardEvent(match, match.PlayerDataA, match.PlayerDataB, playableCardId);

        //        // Assert
        //        Assert.AreEqual(1, playCardEvent.Events.Count);
        //        Assert.IsInstanceOfType(playCardEvent.Events.First(), typeof(PlayerTurnEvent));
        //    }
        //}
        //fin test PlayCardEvent
        //debut tesy PlayCard/ combatEvent
        //  On test l'event PlayCardEvent qui est créé par la méthode PlayCard
        //[TestMethod]
        //public void PlayCardEventCombat_Constructor_ShouldAddCardToBattleField()
        //{
        //    // Arrange
        //    using (var context = new ApplicationDbContext(options))
        //    {
        //        var playerA = context.Players.FirstOrDefault(p => p.Name == "PlayerA");
        //        var playerB = context.Players.FirstOrDefault(p => p.Name == "PlayerB");

        //        var match = new Match
        //        {
        //            PlayerDataA = new MatchPlayerData { PlayerId = playerA.Id },
        //            PlayerDataB = new MatchPlayerData { PlayerId = playerB.Id }
        //        };
        //        context.Matches.Add(match);
        //        context.SaveChanges();

        //        var playableCardId = 1; // Assume this card ID exists in the database

        //        // Act
        //        var playCardEvent = new PlayCardEvent(match, match.PlayerDataA, match.PlayerDataB, playableCardId);

        //        // Assert
        //        Assert.AreEqual(playableCardId, playCardEvent.PlayableCardId);
        //        Assert.AreEqual(match.PlayerDataA.PlayerId, playCardEvent.PlayerId);
        //        Assert.AreEqual(0, match.PlayerDataA.Hand.Count); // Card should be removed from hand
        //        Assert.AreEqual(1, match.PlayerDataA.BattleField.Count); // Card should be added to the battlefield
        //    }
        //}
    }
}