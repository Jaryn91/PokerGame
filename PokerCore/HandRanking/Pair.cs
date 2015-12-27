using System.Collections;
using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore.HandRanking
{
    public class Pair : CheckHand
    {
        public CardFigure WinningFigure { get; private set; }
        public Pair(List<Card> cards)
        {
            _cards = cards;
        }

        public override bool Check()
        {
            var pair = _cards.GroupBy(c => c.Figure).Where(c => c.Count() == 2);
            if (pair.Count() == 1)
            {
                SetWinningFigure(pair);
                return true;
            }
            else
                return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (Pair)secondCheckHand;
            var secondFigure = secondHand.WinningFigure;
            if (ThisFigureWins(secondFigure))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (OtherFigureWins(secondFigure))
                return ResultsOfCompareHands.WinSecondPlayer;
            
            return CompareHandsWihoutWinnigFigures(secondHand);
        }

        private bool OtherFigureWins(CardFigure secondFigure)
        {
            return (int)WinningFigure < (int)secondFigure;
        }

        private bool ThisFigureWins(CardFigure secondFigure)
        {
            return (int)WinningFigure > (int)secondFigure;
        }

        private void SetWinningFigure(IEnumerable<IGrouping<CardFigure, Card>> pair)
        {
            WinningFigure = pair.Select(c => c.Key).First();
        }

        public CardFigure GetWinningFigure()
        {
            return WinningFigure;
        }

        private ResultsOfCompareHands CompareHandsWihoutWinnigFigures(Pair secondHand)
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
    }
}
