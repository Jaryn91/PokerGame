using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.Players
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> PocketCards { get; private set; } 
        public Player(string name)
        {
            Name = name;
            PocketCards = new List<Card>();
        }

        public void GetCardToPocket(Card card)
        {
            PocketCards.Add(card);
        }


        public void AddPocketCard(Card card)
        {
            PocketCards.Add(card);
        }
    }
}
