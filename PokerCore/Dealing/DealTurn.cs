using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Table;

namespace PokerCore.Dealing
{
    public class DealTurn : IDeal
    {
        private SingleTable _singleTable;
        private Deck _deck;
        public DealTurn(SingleTable singleTable, Deck deck)
        {
            _singleTable = singleTable;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetTurnCardsFromDeck();
            _singleTable.PutTurnOnTable(flopCards);
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
