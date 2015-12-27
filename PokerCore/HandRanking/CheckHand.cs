using PokerCore.DeckOfCards;
using System.Collections.Generic;

namespace PokerCore.HandRanking
{
    public abstract class CheckHand
    {
        protected List<Card> _cards;
        public abstract bool Check();
        public abstract ResultsOfCompareHands Compare(CheckHand secondCheckHand);
    }
}
