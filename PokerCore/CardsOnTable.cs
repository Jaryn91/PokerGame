using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore
{
    public class CardsOnTable
    {
        public List<Card> FlopCards;
        public List<Card> TurnCards;
        public List<Card> RiverCards;
        public CardsOnTable()
        {
            FlopCards = new List<Card>();
            TurnCards = new List<Card>();
            RiverCards = new List<Card>();
        }

        public void Flop(List<Card> flopCards)
        {
            FlopCards = flopCards;
        }

        public void Turn(List<Card> turnCards)
        {
            TurnCards = turnCards;
        }

        public void River(List<Card> riverCards)
        {
            RiverCards = riverCards;
        }

        public List<Card> AllCards()
        {
            var allCards = new List<Card>();
            allCards.AddRange(FlopCards);
            allCards.AddRange(TurnCards);
            allCards.AddRange(RiverCards);
            return allCards;
        } 
    }
}
