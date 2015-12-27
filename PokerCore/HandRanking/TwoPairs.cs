using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PokerCore.HandRanking
{
    public class TwoPairs : CheckHand
    {
        public CardFigure WinningHigherFigurePair { get; private set; }
        public CardFigure WinningLowerFigurePair { get; private set; }
        public TwoPairs(List<Card> cards)
        {
            _cards = cards;
        }

        public override bool Check()
        {
            var pairs = _cards.GroupBy(c => c.Figure).Where(c => c.Count() == 2);
            if (pairs.Count() >= 2)
            {
                SetWinningFigures(pairs);
                return true;
            }
            else
                return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (TwoPairs)secondCheckHand;
            var resultOfComparingHigherFigure = CompareHigherFigure(secondHand);
            if (resultOfComparingHigherFigure != ResultsOfCompareHands.Draw)
                return resultOfComparingHigherFigure;

            var resultOfComparingLowerFigure = CompareLowerFigure(secondHand);
            if (resultOfComparingLowerFigure != ResultsOfCompareHands.Draw)
                return resultOfComparingLowerFigure;

            return CompareHandsWihoutWinnigFigures(secondHand);
        }

        private ResultsOfCompareHands CompareHandsWihoutWinnigFigures(TwoPairs secondHand)
        {
            var thisHandWithoutWinningCards = CardsWithoutWinningFigures();
            var otherHandWithoutWinningFigures = secondHand.CardsWithoutWinningFigures();
            var highCard = new HighCard();
            var cardsToCompare = PokerRules.CardsToCreateHand - 4;
            var result = highCard.Compare(thisHandWithoutWinningCards, otherHandWithoutWinningFigures, cardsToCompare);
            return result;
        }

        public List<Card> CardsWithoutWinningFigures()
        {
            return _cards.Where(c => c.Figure != WinningHigherFigurePair ||
                                     c.Figure != WinningLowerFigurePair).ToList();

        }

        private ResultsOfCompareHands CompareHigherFigure(TwoPairs secondHand)
        {
            var secondFigure = secondHand.WinningHigherFigurePair;
            if (FirstFigureWins(WinningHigherFigurePair, secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (SecondFigureWins(WinningHigherFigurePair, secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private ResultsOfCompareHands CompareLowerFigure(TwoPairs secondHand)
        {
            var secondFigure = secondHand.WinningHigherFigurePair;
            if (FirstFigureWins(WinningHigherFigurePair, secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;
            if (SecondFigureWins(WinningHigherFigurePair, secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            secondFigure = secondHand.WinningLowerFigurePair;
            if (FirstFigureWins(WinningLowerFigurePair, secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;
            if (SecondFigureWins(WinningLowerFigurePair, secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private bool FirstFigureWins(CardFigure firstFigure, CardFigure secondFigure)
        {
            return firstFigure > secondFigure;
        }

        private bool SecondFigureWins(CardFigure firstFigure, CardFigure secondFigure)
        {
            return firstFigure < secondFigure;
        }

        private void SetWinningFigures(IEnumerable<IGrouping<CardFigure, Card>> threeOfKind)
        {
            var orderedWinningFigures = threeOfKind.Select(c => (int)c.Key).OrderByDescending(c => c).ToList();
            WinningHigherFigurePair = (CardFigure)orderedWinningFigures[0];
            WinningLowerFigurePair = (CardFigure)orderedWinningFigures[1];
        }
        public CardFigure GetHigherWinningFigure()
        {
            return WinningHigherFigurePair;
        }

        public CardFigure GetLowerWinningFigure()
        {
            return WinningLowerFigurePair;
        }
    }
}
