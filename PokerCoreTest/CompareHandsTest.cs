using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerCore.DeckOfCards;
using PokerCore.HandRanking;

namespace PokerCoreTest
{
    [TestClass]
    public class CompareHandsTest
    {
        [TestMethod]
        public void CompareHands()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.King, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Queen, CardSuit.Diamonds),
                new Card(CardFigure.Queen, CardSuit.Hearts),
                new Card(CardFigure.Ace, CardSuit.Spades),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Clubs)
            };

            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }

        public void ComparePairs()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.King, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.King, CardSuit.Diamonds)
            };

            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }

        [TestMethod]
        public void CompareTwoPairs()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };

            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }

        [TestMethod]
        public void CompareThreeOfKind()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Spades),
                new Card(CardFigure.Ten, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };

            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }


        [TestMethod]
        public void CompareFullHouse()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Nine, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Nine, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }

        [TestMethod]
        public void CompareFlush()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Clubs)
            };
            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Ace, CardSuit.Clubs)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinSecondPlayer, compareHands.Compare());
        }

        [TestMethod]
        public void CompareStraight()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Seven, CardSuit.Clubs),
                new Card(CardFigure.Six, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Diamonds)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Four, CardSuit.Hearts),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Clubs),
                new Card(CardFigure.Two, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Three, CardSuit.Diamonds)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinFirstPlayer, compareHands.Compare());
        }

        [TestMethod]
        public void CompareStraightWithAce()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Two, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Three, CardSuit.Hearts),
                new Card(CardFigure.Five, CardSuit.Hearts)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Two, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Three, CardSuit.Hearts),
                new Card(CardFigure.Five, CardSuit.Hearts)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.Draw, compareHands.Compare());
        }

        [TestMethod]
        public void CompareFourOfKind()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Queen, CardSuit.Diamonds),
                new Card(CardFigure.Queen, CardSuit.Hearts),
                new Card(CardFigure.Queen, CardSuit.Spades),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Clubs)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Queen, CardSuit.Diamonds),
                new Card(CardFigure.Queen, CardSuit.Hearts),
                new Card(CardFigure.Queen, CardSuit.Spades),
                new Card(CardFigure.King, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Clubs)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinFirstPlayer, compareHands.Compare());

        }


        [TestMethod]
        public void CompareStraightFlush()
        {
            var firstPlayerCards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs)
            };

            var secondPlayerCards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs)
            };
            var compareHands = new CompareHands(firstPlayerCards, secondPlayerCards);
            Assert.AreEqual(ResultsOfCompareHands.WinFirstPlayer, compareHands.Compare());
        }
    }
}
