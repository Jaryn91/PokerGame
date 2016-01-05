using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.Beting;
using PokerCore.Beting.Blind;
using PokerCore.DeckOfCards;
using PokerCore.Players;
using PokerCore.Table;

namespace PokerCore
{
    public class SingleGame
    {
        private List<Player> _players;
        private SingleTable _singleTable;
        private Blinds _blinds;

        public SingleGame(List<Player> players, SingleTable singleTable, Blinds blinds)
        {
            _players = players;
            _singleTable = singleTable;
            _blinds = blinds;
        }

        public void StartGame()
        {
            var deck = new Deck();
            deck.Shuffle();
        }
    }
}
