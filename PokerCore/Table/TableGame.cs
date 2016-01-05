using System.Collections.Generic;
using PokerCore.Beting;
using PokerCore.Beting.Blind;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Table
{
    public class TableGame
    {
        private readonly PlayersPosition _playersPosition;          
        private Blinds _blinds;
        public List<Player> Players; 

        public TableGame(List<Player> players, Blinds blinds)
        {
            Players = players;
            _playersPosition = new PlayersPosition(players);
            _blinds = blinds;
        }

        public void InitGame()
        {
            _playersPosition.RandomPositionPlayers();
            _playersPosition.SetStartPlayersPositions();
            var startChips = new StartChips(Players);
            startChips.SetToPlayers();
        }

        public void StartGame()
        {

        }
    }
}
