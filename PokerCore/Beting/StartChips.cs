using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.Players;

namespace PokerCore.Beting
{
    public class StartChips
    {
        private readonly List<Player> _players;

        public StartChips(List<Player> players)
        {
            _players = players;
        }

        public void SetToPlayers()
        {
            foreach (var player in _players)
            {
                var chip = new Chips(PokerRules.StartChips);
                player.SetStartChips(chip);
            }  
        }
    }
}
