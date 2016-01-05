using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.Beting.Blind;
using PokerCore.Beting.Blind.Standard;
using PokerCore.Players;

namespace PokerCoreTest
{
    public class ExampleDate
    {
        public List<Player> GetFourPlayers()
        {
            var playerOne = new Player("John");
            var playerTwo = new Player("Mark");
            var playerThree = new Player("Arun");
            var playerFour = new Player("Miheal");
            var players = new List<Player>
            {
                playerOne, playerTwo, playerThree, playerFour
            };
            return players;
        }

        public Blinds GetStandardBlinds()
        {
            var smallBlindLevel = new StandardSmallBlind();
            var bigBlindLevel = new StandardBigBlind();
            var anteLevel = new StandardAnte();
            return new Blinds(bigBlindLevel, smallBlindLevel, anteLevel);
        }
    }
}
