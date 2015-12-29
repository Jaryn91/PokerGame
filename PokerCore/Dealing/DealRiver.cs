using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealRiver :IDeal
    {
        private SingleTable _singleTable;
        private Deck _deck;

        public DealRiver(SingleTable singleTable, Deck deck)
        {
            _singleTable = singleTable;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetRiverCardsFromDeck();
            _singleTable.PutRiverOnTable(flopCards);
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
