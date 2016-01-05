using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealTableCardsRiver :IDealTableCards
    {
        private Deck _deck;

        public DealTableCardsRiver(Deck deck)
        {
            _deck = deck;
        }

        public List<Card> Deal()
        {
            var riverCards = GetRiverCardsFromDeck();
            return riverCards;
        }

        private List<Card> GetRiverCardsFromDeck()
        {
            var flopCards = new List<Card>();
            for (var i = 0; i < PokerRules.RiverCards; i++)
            {
                var card = _deck.TakeCard();
                flopCards.Add(card);
            }
            return flopCards;
        }
    }
}
