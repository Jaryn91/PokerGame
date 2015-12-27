using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore.HandRanking
{
    public class Flush : CheckHand
    {
        private List<Card> _allFlushCards;
        private List<Card> _winnigCards;

        public Flush(List<Card> cards)
        {
            _cards = cards;
        }
        public override bool Check()
        {
            var flush = _cards.GroupBy(c => c.Suit).Where(c => c.Count() >= 5);
            if (flush.Count() == 1)
            {
                SetAllFlushCards(flush);
                SetWinnigFlushCards();
                return true;
            }
            else
                return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (Flush)secondCheckHand;
            var secondHandWinnigCards = secondHand.GetWinngingFlushCards();
            var highCard = new HighCard();
            return highCard.Compare(_winnigCards, secondHandWinnigCards, PokerRules.CardsToCreateHand);
        }

        private ResultsOfCompareHands ThisFlushWins(Flush secondHand)
        {
            var secondHandWinnigCards = secondHand.GetWinngingFlushCards();
            var compareHands = new CompareHands(_winnigCards, secondHandWinnigCards);
            var result = compareHands.Compare();
            return result;
        }

        private void SetWinnigFlushCards()
        {
            var orderByDescendingFigure = _allFlushCards.OrderByDescending(c => (int) c.Figure);
            _winnigCards = orderByDescendingFigure.Take(PokerRules.CardsToCreateHand).ToList();
        }

        private void SetAllFlushCards(IEnumerable<IGrouping<CardSuit, Card>> flush)
        {
            var winningSuit = flush.Select(c => c.Key).OrderByDescending(c => c).First();
            _allFlushCards = _cards.Where(c => c.Suit == winningSuit).ToList();
        }


        public List<Card> GetWinngingFlushCards()
        {
            return _winnigCards;
        }


        public List<Card> GetAllFlushCards()
        {
            return _allFlushCards;
        }
    }
}
