using System.Collections.Generic;
using PokerCore.Beting;
using PokerCore.DeckOfCards;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Players
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> PocketCards { get; private set; } 
        public Chips Chips { get; private set; }

        public Position Position;
        public Player(string name)
        {
            Name = name;
            PocketCards = new List<Card>();
        }

        public void SetStartChips(Chips chips)
        {
            Chips = chips;
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
