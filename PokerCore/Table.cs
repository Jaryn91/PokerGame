using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Players;

namespace PokerCore
{
    public class Table
    {
        public List<Player> Players;
        public CardsOnTable Cards;
        public Table()
        {
            Players = new List<Player>();
            Cards = new CardsOnTable();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void PutFlopOnTable(List<Card> flopCards)
        {
            Cards.FlopCards = flopCards;
        }

        public void PutTurnOnTable(List<Card> turnCards)
        {
            Cards.TurnCards = turnCards;
        }

        public void PutRiverOnTable(List<Card> riverCards)
        {
            Cards.RiverCards = riverCards;
        }
    }
}
