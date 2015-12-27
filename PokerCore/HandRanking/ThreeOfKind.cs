using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PokerCore.HandRanking
{
    public class ThreeOfKind : CheckHand
    {
        public CardFigure WinningFigure { get; private set; }
        public ThreeOfKind(List<Card> cards)
        {
            _cards = cards;
        }
        public override bool Check()
        {
            var threeOfKind = _cards.GroupBy(c => c.Figure).Where(c => c.Count() == 3);
            if (threeOfKind.Any())
            {
                if (ExistTwoThreeOfKind(threeOfKind))
                {
                    SetWinningHigherFigure(threeOfKind);
                }
                else
                {
                    SetWinningFigure(threeOfKind); 
                }
                
                return true;
            }
            else
                return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (ThreeOfKind)secondCheckHand;
            var secondFigure = secondHand.WinningFigure;
            if (ThisFigureWins(secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (OtherFigureWins(secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return CompareHandsWihoutWinnigFigures(secondHand);
        }

        private ResultsOfCompareHands CompareHandsWihoutWinnigFigures(ThreeOfKind secondHand)
        {
            var thisHandWithoutWinningCards = CardsWithoutWinningFigures();
            var otherHandWithoutWinningFigures = secondHand.CardsWithoutWinningFigures();
            var highCard = new HighCard();
            var cardsToCompare = PokerRules.CardsToCreateHand - 3;
            var result = highCard.Compare(thisHandWithoutWinningCards, otherHandWithoutWinningFigures, cardsToCompare);
            return result;
        }

        public List<Card> CardsWithoutWinningFigures()
        {
            return _cards.Where(c => c.Figure != WinningFigure).ToList();
        }

        private bool OtherFigureWins(CardFigure secondFigure)
        {
            return (int)WinningFigure < (int)secondFigure;
        }

        private bool ThisFigureWins(CardFigure secondFigure)
        {
            return (int)WinningFigure > (int)secondFigure;
        }

        private void SetWinningFigure(IEnumerable<IGrouping<CardFigure, Card>> threeOfKind)
        {
            WinningFigure = threeOfKind.Select(c => c.Key).First();
        }

        private void SetWinningHigherFigure(IEnumerable<IGrouping<CardFigure, Card>> threeOfKind)
        {
            var valueOfWinningFigure = threeOfKind.Select(c => (int) c.Key).OrderByDescending(c => c).First();
            WinningFigure = (CardFigure) valueOfWinningFigure;
        }

        private bool ExistTwoThreeOfKind(IEnumerable<IGrouping<CardFigure, Card>> threeOfKind)
        {
            return threeOfKind.Count() >= 2;
        }

        public CardFigure GetWinningFigure()
        {
            return WinningFigure;
        }

    }
}
