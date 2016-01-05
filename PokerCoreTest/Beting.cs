using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore;
using PokerCore.Players;
using PokerCore.Table;

namespace PokerCoreTest
{
    [TestClass]
    public class Beting
    {
        [TestMethod]
        public void InitTableGame()
        {
            var exampleDate = new ExampleDate();
            var players = exampleDate.GetFourPlayers();
            var blinds = exampleDate.GetStandardBlinds();
            var tableGame = new TableGame(players, blinds);
            tableGame.InitGame();

            Assert.IsTrue(players.TrueForAll(p=>p.Chips.Amount == PokerRules.StartChips));
            Assert.AreEqual(tableGame.Players.Count, players.Count);
        }

        [TestMethod]
        public void PreFlopAllCallAndCheck()
        {
            var exampleDate = new ExampleDate();
            var players = exampleDate.GetFourPlayers();
            var blinds = exampleDate.GetStandardBlinds();
            var blindsLevel = 1;
            var playHand = new PlayHandOnTable(players, blinds, blindsLevel);

            playHand.PreFlop();

            var bigBlindValue = blinds.BigBlind.GetValueFromLevel(blindsLevel);
            var expectedChipsInPot = players.Count*bigBlindValue;
            Assert.AreEqual(expectedChipsInPot, playHand.Pot.Amount);
        }
    }
}
