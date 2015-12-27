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
    public class HandRankingTest
    {
        [TestMethod]
        public void EvaluatePair()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.King, CardSuit.Diamonds)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);          
        }

        [TestMethod]
        public void EvaluateTwoPairs()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Nine, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }

        [TestMethod]
        public void EvaluateThreeOfKind()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Spades),
                new Card(CardFigure.Six, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Two, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }

       
        [TestMethod]
        public void EvaluateFullHouse()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Jack, CardSuit.Spades),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Diamonds)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreEqual(PowerOfHand.FullHouse, hand);
        }

        [TestMethod]
        public void EvaluateFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Nine, CardSuit.Clubs)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }

        [TestMethod]
        public void EvaluateStraight()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Seven, CardSuit.Clubs),
                new Card(CardFigure.Six, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Diamonds)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }

        [TestMethod]
        public void EvaluateStraightWithAce()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Two, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.Four, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Three, CardSuit.Hearts),
                new Card(CardFigure.Five, CardSuit.Hearts)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }

        [TestMethod]
        public void EvaluateFourOfKind()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Queen, CardSuit.Diamonds),
                new Card(CardFigure.Queen, CardSuit.Hearts),
                new Card(CardFigure.Queen, CardSuit.Spades),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Hearts),
                new Card(CardFigure.Eight, CardSuit.Clubs)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }


        [TestMethod]
        public void EvaluateStraightFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardFigure.Queen, CardSuit.Clubs),
                new Card(CardFigure.Jack, CardSuit.Clubs),
                new Card(CardFigure.King, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Clubs),
                new Card(CardFigure.Ace, CardSuit.Diamonds),
                new Card(CardFigure.Five, CardSuit.Clubs),
                new Card(CardFigure.Ten, CardSuit.Clubs)
            };
            var evaluate = new EvaluateHand(cards);
            var hand = evaluate.Evaluate();
            Assert.AreNotEqual(PowerOfHand.HightCard, hand);
            Assert.AreNotEqual(PowerOfHand.Pair, hand);
            Assert.AreNotEqual(PowerOfHand.TwoPairs, hand);
            Assert.AreNotEqual(PowerOfHand.ThreeOfKind, hand);
            Assert.AreNotEqual(PowerOfHand.Straight, hand);
            Assert.AreNotEqual(PowerOfHand.Flush, hand);
            Assert.AreNotEqual(PowerOfHand.FourOfKind, hand);
            Assert.AreEqual(PowerOfHand.StraightFlush, hand);
            Assert.AreNotEqual(PowerOfHand.FullHouse, hand);
        }
    }
}
