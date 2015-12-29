using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealFlop : IDeal
    {
        private Deck _deck;
        private SingleTable _singleTable;

        public DealFlop(SingleTable singleTable, Deck deck)
        {
            _singleTable = singleTable;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetFlopCardsFromDeck();
            _singleTable.PutFlopOnTable(flopCards);
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
