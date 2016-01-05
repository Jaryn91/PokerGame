using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore;
using PokerCore.Dealing;
using PokerCore.DeckOfCards;
using PokerCore.Players;
using PokerCore.Table;

namespace PokerCoreTest
{
    [TestClass]
    public class DealingTest
    {
        [TestMethod]
        public void DealPockectCards()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Miheal");
            var players = new List<Player> {playerOne, playerTwo};
            var deck = new Deck();
            deck.Shuffle();
            var dealPocketCards = new DealPocketCards(players, deck);
            dealPocketCards.Deal();

            CollectionAssert.AllItemsAreUnique(playerOne.PocketCards);
            CollectionAssert.AllItemsAreUnique(playerTwo.PocketCards);
            CollectionAssert.DoesNotContain(deck.Cards, playerOne.PocketCards);
            CollectionAssert.DoesNotContain(deck.Cards, playerTwo.PocketCards);
            CollectionAssert.AllItemsAreUnique(playerOne.PocketCards);
            CollectionAssert.AllItemsAreUnique(playerTwo.PocketCards);
        }

        [TestMethod]
        public void PutCardsOnTable()
        {
            var exampleDate = new ExampleDate();
            var players = exampleDate.GetFourPlayers();
            var blinds = exampleDate.GetStandardBlinds();
            var blindsLevel = 1;
            var playHand = new PlayHandOnTable(players, blinds, blindsLevel);
            var deck = new Deck();
            deck.Shuffle();
            
            playHand.PutFlopOnTable();
            playHand.PutTurnOnTable();
            playHand.PutRiverOnTable();

            var allCardsOnTable = playHand.TableCards.AllCards();
            Assert.AreEqual(5, allCardsOnTable.Count);
            CollectionAssert.AllItemsAreUnique(allCardsOnTable);
        }



    }
}
