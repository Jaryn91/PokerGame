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

        public Position Position { get; set; }
        public Player(string name)
        {
            Name = name;
            PocketCards = new List<Card>();
            Position = Position.None;
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

        public void PaySmallBlind(int amountOfChips, Pot pot)
        {
            Chips.SmallBlindIntoPot(amountOfChips, pot);
        }

        public void PayBigBlind(int amountOfChips, Pot pot)
        {
            Chips.BigBlindIntoPot(amountOfChips, pot);
        }
        public void PayAnte(int amountOfChips, Pot pot)
        {
            Chips.AnteIntoPot(amountOfChips, pot);
        }

    }
}
