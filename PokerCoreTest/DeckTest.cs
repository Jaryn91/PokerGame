using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;
using PokerCore.HandRanking;

namespace PokerCoreTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CreateDeck()
        {
            var deck = new Deck();
            Assert.AreEqual(52, deck.Cards.Count);
            CollectionAssert.AllItemsAreUnique(deck.Cards);
        }

        [TestMethod]
        public void Shuffle()
        {
            var deck = new Deck();
            var shuffleDeck = new Deck();
            shuffleDeck.Shuffle();
            Assert.IsFalse(deck.Cards.SequenceEqual(shuffleDeck.Cards));

        }
    }
}
