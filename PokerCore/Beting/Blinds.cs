using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.Players;

namespace PokerCore.Beting
{
    public class Blinds
    {
        public int SmallBlind;
        public int BigBlind;
        public int Ante;
        private List<Player> _players;

        public Blinds(List<Player> players)
        {
            _players = players;
        }

        public void GetBlinds()
        {
            GetSmallBlindFromPlayers();
            GetBigBlindFromPlayers();
            GetAnteFromPlayers();
        }

        private void GetAnteFromPlayers()
        {
           
        }

        private void GetBigBlindFromPlayers()
        {


        }

        private void GetSmallBlindFromPlayers()
        {


        }
    }
}
