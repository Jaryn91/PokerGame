using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.Dealing
{
    public class DealFlop
    {
        private Deck _deck;
        private Table _table;

        public DealFlop(Table table, Deck deck)
        {
            _table = table;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetFlopCardsFromDeck();
            _table.PutFlopOnTable(flopCards);
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
