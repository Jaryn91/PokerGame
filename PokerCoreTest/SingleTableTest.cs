using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore;
using PokerCore.Beting;
using PokerCore.Beting.Blind;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;
using PokerCore.Table;

namespace PokerCoreTest
{
    [TestClass]
    public class SingleTableTest
    {
        [TestMethod]
        public void AddPlayersToTable()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var table = new SingleTable();
            table.AddPlayer(playerOne);
            table.AddPlayer(playerTwo);
            table.AddPlayer(playerThree);

            var playersAtTable = table.Players.Count;

            Assert.AreEqual(3, playersAtTable);
        }


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

            var playersPosition = new PlayersPosition();    
            playersPosition.SetStartPlayersPositions(players);
            playersPosition.MoveDealerButton(players);
            playersPosition.MoveDealerButton(players);

            var dealer = playersPosition.GetDealer(players);
            var smallBlind = playersPosition.SmallBlindPlayer(players);
            var bigBlind = playersPosition.BigBlindPlayer(players);
            Assert.AreEqual(playerThree, dealer);
            Assert.AreEqual(playerFour, smallBlind);
            Assert.AreEqual(playerOne, bigBlind);
        }

        [TestMethod]
        public void DealStartChips()
        {
            var player = new Player("John");
            var chip = new Chips(PokerRules.StartChips);
            player.SetStartChips(chip);

            Assert.AreEqual(player.Chips.Amount, PokerRules.StartChips);
        }

        [TestMethod]
        public void SetStartChipsToPlayers()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var playerFour = new Player("John");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };

            var startChips = new StartChips();
            startChips.SetToPlayers(players);

            Assert.AreEqual(playerOne.Chips.Amount, PokerRules.StartChips);
            Assert.AreEqual(playerTwo.Chips.Amount, PokerRules.StartChips);
            Assert.AreEqual(playerThree.Chips.Amount, PokerRules.StartChips);
            Assert.AreEqual(playerFour.Chips.Amount, PokerRules.StartChips);
        }


        [TestMethod]
        public void GetBlinds()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var playerFour = new Player("Miheal");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };

            var pot = new Pot();
            var levelBlinds = 1;
            var playersPosition = new PlayersPosition();
            playersPosition.SetStartPlayersPositions(players);
            var startChips = new StartChips();
            startChips.SetToPlayers(players);
            var smallBlindLevel = new SmallBlindLevel();
            var bigBlindLevel = new BigBlindsLevel();
            var anteLevel = new AnteLevel();
            

            var getBlinds = new Blinds(players, levelBlinds, pot, smallBlindLevel, bigBlindLevel, anteLevel);
            getBlinds.GetBlinds();

            var expectedPot = smallBlindLevel.GetValueFromLevel(levelBlinds) +
                              bigBlindLevel.GetValueFromLevel(levelBlinds);

            Assert.AreEqual(pot.Amount, expectedPot);

            var expectedSmallBlindAmout = PokerRules.StartChips - smallBlindLevel.GetValueFromLevel(levelBlinds);
            var smallBlindPlayer = playersPosition.SmallBlindPlayer(players);
            Assert.AreEqual(smallBlindPlayer.Chips.Amount, expectedSmallBlindAmout);

            var expectedBigBlindAmout = PokerRules.StartChips - bigBlindLevel.GetValueFromLevel(levelBlinds);
            var bigBlindPlayer = playersPosition.BigBlindPlayer(players);
            Assert.AreEqual(bigBlindPlayer.Chips.Amount, expectedBigBlindAmout);

            var otherPlayers = players.Where(p => p != smallBlindPlayer && 
                               p != bigBlindPlayer).ToList();
            Assert.IsTrue(otherPlayers.TrueForAll(p => p.Chips.Amount == PokerRules.StartChips));         
        }

    }
}
