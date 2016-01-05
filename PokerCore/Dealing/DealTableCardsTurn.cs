using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealTableCardsTurn : IDealTableCards
    {
        private Deck _deck;
        public DealTableCardsTurn(Deck deck)
        {
            _deck = deck;
        }

        public List<Card> Deal()
        {
            var turnCards = GetTurnCardsFromDeck();
            return turnCards;
        }

        private List<Card> GetTurnCardsFromDeck()
        {
            var flopCards = new List<Card>();
            for (var i = 0; i < PokerRules.TurnCards; i++)
            {
                var card = _deck.TakeCard();
                flopCards.Add(card);
            }
            return flopCards;
        }
    }
}
