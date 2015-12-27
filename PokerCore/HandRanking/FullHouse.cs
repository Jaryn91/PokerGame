using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace PokerCore.HandRanking
{
    public class FullHouse : CheckHand
    {
        public CardFigure WinningFigureThreeOfKind { get; private set; }
        public CardFigure WinningFigurePair { get; private set; }

        public FullHouse(List<Card> cards)
        {
            _cards = cards;
        }

        public override bool Check()
        {
            var threeOfKind = new ThreeOfKind(_cards);
            if (threeOfKind.Check())
            {
                WinningFigureThreeOfKind = threeOfKind.GetWinningFigure();
                var cardsWithoutThreeOfKind = RemoveCardsWithFigure(WinningFigureThreeOfKind);
                if (FindPair(cardsWithoutThreeOfKind))
                    return true;
            }
            return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (FullHouse)secondCheckHand;
            var resultOfComparingHigherFigure = CompareThreeOfKindFigure(secondHand);
            if (resultOfComparingHigherFigure != ResultsOfCompareHands.Draw)
                return resultOfComparingHigherFigure;

            var resultOfComparingLowerFigure = ComparePairFigure(secondHand);
            if (resultOfComparingLowerFigure != ResultsOfCompareHands.Draw)
                return resultOfComparingLowerFigure;

            return ResultsOfCompareHands.Draw;
        }

        private ResultsOfCompareHands ComparePairFigure(FullHouse secondHand)
        {
            var secondFigure = secondHand.WinningFigurePair;
            if (FirstFigureWins(WinningFigurePair, secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;
            if (SecondFigureWins(WinningFigurePair, secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private ResultsOfCompareHands CompareThreeOfKindFigure(FullHouse secondHand)
        {
            var secondFigure = secondHand.WinningFigureThreeOfKind;
            if (FirstFigureWins(WinningFigureThreeOfKind, secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;
            if (SecondFigureWins(WinningFigureThreeOfKind, secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private bool SecondFigureWins(CardFigure firstFigure, CardFigure secondFigure)
        {
            return firstFigure < secondFigure;
        }

        private bool FirstFigureWins(CardFigure firstFigure, CardFigure secondFigure)
        {
            return firstFigure > secondFigure;
        }

        private bool FindPair(List<Card> cardsToFindPair)
        {
            var pair = new Pair(cardsToFindPair); //AAAKKQJ
            if (pair.Check())
            {
                WinningFigurePair = pair.GetWinningFigure();
                return true;
            }

            var twoPairs = new TwoPairs(cardsToFindPair); // AAAKKQQ
            if (twoPairs.Check())
            {
                    WinningFigurePair = twoPairs.GetHigherWinningFigure();
                    return true;                
            }

            var threeOfKind = new ThreeOfKind(cardsToFindPair); //AAAKKKQ
            if (threeOfKind.Check())
            {
                WinningFigurePair = threeOfKind.GetWinningFigure();
                return true;

            }
            return false;
        }

        private List<Card> RemoveCardsWithFigure(CardFigure figure)
        {
            return _cards.Where(c => c.Figure != figure).ToList();
        }
    }
}
