using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.Dealing
{
    public class DealRiver
    {
        private Table _table;
        private Deck _deck;

        public DealRiver(Table table, Deck deck)
        {
            _table = table;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetRiverCardsFromDeck();
            _table.PutRiverOnTable(flopCards);
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
