using System.Collections.Generic;
using PokerCore.Beting.Blind;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Beting
{
    public class PreFlopGame
    {
        private List<Player> _players;
        private Pot _pot;
        private Blinds _blinds;

        public PreFlopGame(List<Player> players, Pot pot, Blinds blinds)
        {
            _players = players;
            _pot = pot;
            _blinds = blinds;
        }

        public void Play()
        {
            var bigBlindPlayer = BigBlindPlayer();
            _players.NextOf(bigBlindPlayer);
        }

        private Player BigBlindPlayer()
        {
            PlayersPosition playersPosition = new PlayersPosition(_players);
            return playersPosition.BigBlindPlayer();
        }

    }
}