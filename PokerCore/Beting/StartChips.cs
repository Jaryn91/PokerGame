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
        public void SetToPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                var chip = new Chips(PokerRules.StartChips);
                player.SetStartChips(chip);
            }  
        }
    }
}
