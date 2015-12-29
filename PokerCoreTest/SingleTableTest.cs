using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore;
using PokerCore.Beting;
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
            var playerFour = new Player("John");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };

            var playersPosition = new PlayersPosition();    
            playersPosition.SetStartPlayersPositions(players);
            playersPosition.MoveDealerButton(players);
            playersPosition.MoveDealerButton(players);

            var dealer = playersPosition.GetDealer(players);
            var smallBlind = playersPosition.GetSmallBlind(players);
            var bigBlind = playersPosition.GetBigBlind(players);
            Assert.AreEqual(playerThree, dealer);
            Assert.AreEqual(playerFour, smallBlind);
            Assert.AreEqual(playerOne, bigBlind);
        }


        [TestMethod]
        public void GetBlinds()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var playerFour = new Player("John");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };

            var playersPosition = new PlayersPosition();
            playersPosition.SetStartPlayersPositions(players);
            var getBlinds = new Blinds(players);

            var dealer = playersPosition.GetDealer(players);
            var smallBlind = playersPosition.GetSmallBlind(players);
            var bigBlind = playersPosition.GetBigBlind(players);
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

            Assert.AreEqual(player.Chips.Amount, 3000);
        }

      
    }
}
