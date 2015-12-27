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
            var table = new Table();
            var deck = new Deck();
            deck.Shuffle();
            var dealFlop = new DealFlop(table, deck);
            dealFlop.Deal();
            var dealTurn = new DealTurn(table, deck);
            dealTurn.Deal();
            var dealRiver = new DealRiver(table, deck);
            dealRiver.Deal();

            var allCardsOnTable = table.Cards.AllCards();
            Assert.AreEqual(5, allCardsOnTable.Count);
            CollectionAssert.AllItemsAreUnique(allCardsOnTable);
        }



    }
}
