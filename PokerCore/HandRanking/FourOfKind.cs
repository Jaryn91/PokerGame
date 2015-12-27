using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore.HandRanking
{
    public class FourOfKind : CheckHand
    {
        public CardFigure WinningFigure { get; private set; }
        public FourOfKind(List<Card> cards)
        {
            _cards = cards;
        }

        public override bool Check()
        {
            var fourOfKind = _cards.GroupBy(c => c.Figure).Where(c => c.Count() == 4);
            if (fourOfKind.Count() == 1)
            {
                SetWinningFigure(fourOfKind);
                return true;
            }

            return false;
        }

        private void SetWinningFigure(IEnumerable<IGrouping<CardFigure, Card>> fourOfKind)
        {
            WinningFigure = fourOfKind.Select(c => c.Key).First();
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (FourOfKind)secondCheckHand;
            var secondFigure = secondHand.WinningFigure;
            if (ThisFigureWins(secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (OtherFigureWins(secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;

            return CompareHandsWihoutWinnigFigures(secondHand);
        }

        private ResultsOfCompareHands CompareHandsWihoutWinnigFigures(FourOfKind secondHand)
        {
            var thisHandWithoutWinningCards = CardsWithoutWinningFigures();
            var otherHandWithoutWinningFigures = secondHand.CardsWithoutWinningFigures();
            var highCard = new HighCard();
            var cardsToCompare = PokerRules.CardsToCreateHand - 2;
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
    }
}
