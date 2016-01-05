using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealTableCardsFlop : IDealTableCards
    {
        private Deck _deck;
        private PlayHandOnTable _playHandOnTable;

        public DealTableCardsFlop(Deck deck)
        {
            _deck = deck;
        }

        public List<Card> Deal()
        {
            var flopCards = GetFlopCardsFromDeck();
            return flopCards;
        }

        private List<Card> GetFlopCardsFromDeck()
        {
            var flopCards = new List<Card>();
            for (var i = 0; i < PokerRules.FlopCards; i++)
            {
                var card = _deck.TakeCard();
                flopCards.Add(card);
            }
            return flopCards;
        }
    }

}
