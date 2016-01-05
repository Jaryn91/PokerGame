using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.Beting.Blind;
using PokerCore.Beting.Blind.Standard;
using PokerCore.Players;
using PokerCore.Table;

namespace PokerCore
{
    public class Game
    {
        private readonly List<Player> _players; 
        public Game()
        {
             _players = new List<Player>();   
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void AddPlayer(List<Player> players)
        {
            _players.AddRange(players);
        }

        public void StartGame()
        {
            var blinds = new Blinds(new StandardBigBlind(), new StandardSmallBlind(), new StandardAnte());
            var singleGame = new TableGame(_players, blinds);
            singleGame.InitGame();
        }
    }
}
