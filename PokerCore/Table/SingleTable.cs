using System;
using System.Collections.Generic;
using PokerCore.Beting;
using PokerCore.DeckOfCards;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Table
{
    public class SingleTable
    {
        public List<Player> Players;
        public CardsOnTable TableCards;
        public SingleTable()
        {
            Players = new List<Player>();
            TableCards = new CardsOnTable();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void PutFlopOnTable(List<Card> flopCards)
        {
            TableCards.FlopCards = flopCards;
        }

        public void PutTurnOnTable(List<Card> turnCards)
        {
            TableCards.TurnCards = turnCards;
        }

        public void PutRiverOnTable(List<Card> riverCards)
        {
            TableCards.RiverCards = riverCards;
        }
    }
}
