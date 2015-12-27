using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.Dealing
{
    public class DealTurn
    {
        private Table _table;
        private Deck _deck;
        public DealTurn(Table table, Deck deck)
        {
            _table = table;
            _deck = deck;
        }

        public void Deal()
        {
            var flopCards = GetTurnCardsFromDeck();
            _table.PutTurnOnTable(flopCards);
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
