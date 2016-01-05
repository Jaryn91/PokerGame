using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore;
using PokerCore.Beting;
using PokerCore.Beting.Blind;
using PokerCore.Beting.Blind.Standard;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;
using PokerCore.Table;

namespace PokerCoreTest
{
    [TestClass]
    public class SingleTableTest
    {
        [TestMethod]
        public void MoveDealerButtonsTwoTimes()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var playerFour = new Player("Mikheal");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };

            var playersPosition = new PlayersPosition(players);    
            playersPosition.SetStartPlayersPositions();
            playersPosition.MoveDealerButton();
            playersPosition.MoveDealerButton();

            var dealer = playersPosition.GetDealer();
            var smallBlind = playersPosition.SmallBlindPlayer();
            var bigBlind = playersPosition.BigBlindPlayer();
            Assert.AreEqual(playerThree, dealer);
            Assert.AreEqual(playerFour, smallBlind);
            Assert.AreEqual(playerOne, bigBlind);
        }


        [TestMethod]
        public void SetStartChipsToPlayers()
        {
            var examplePlayer = new ExampleDate();
            var players = examplePlayer.GetFourPlayers();

            var startChips = new StartChips(players);
            startChips.SetToPlayers();

            Assert.IsTrue(players.TrueForAll(p => p.Chips.Amount == PokerRules.StartChips));
        }


        [TestMethod]
        public void GetBlinds()
        {
            var examplePlayer = new ExampleDate();
            var players = examplePlayer.GetFourPlayers();
            var pot = new Pot();
            var levelBlinds = 1;
            var playersPosition = new PlayersPosition(players);
            playersPosition.SetStartPlayersPositions();
            var startChips = new StartChips(players);
            startChips.SetToPlayers();
            var smallBlindLevel = new StandardSmallBlind();
            var bigBlindLevel = new StandardBigBlind();
            var anteLevel = new StandardAnte();
            var blinds = new Blinds(bigBlindLevel, smallBlindLevel, anteLevel);


            var getBlinds = new PayBlinds(players, levelBlinds, pot, blinds);
            getBlinds.GetBlinds();



            var expectedPot = smallBlindLevel.GetValueFromLevel(levelBlinds) +
                              bigBlindLevel.GetValueFromLevel(levelBlinds);

            Assert.AreEqual(pot.Amount, expectedPot);

            var expectedSmallBlindAmout = PokerRules.StartChips - smallBlindLevel.GetValueFromLevel(levelBlinds);
            var smallBlindPlayer = playersPosition.SmallBlindPlayer();
            Assert.AreEqual(smallBlindPlayer.Chips.Amount, expectedSmallBlindAmout);

            var expectedBigBlindAmout = PokerRules.StartChips - bigBlindLevel.GetValueFromLevel(levelBlinds);
            var bigBlindPlayer = playersPosition.BigBlindPlayer();
            Assert.AreEqual(bigBlindPlayer.Chips.Amount, expectedBigBlindAmout);

            var otherPlayers = players.Where(p => p != smallBlindPlayer && 
                               p != bigBlindPlayer).ToList();
            Assert.IsTrue(otherPlayers.TrueForAll(p => p.Chips.Amount == PokerRules.StartChips));         
        }
    }
}
