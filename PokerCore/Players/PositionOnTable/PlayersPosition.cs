using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.Players.PositionOnTable
{
    public class PlayersPosition
    {
        private readonly List<Player> _players;

        public PlayersPosition(List<Player> players)
        {
            _players = players;
        }

        public void SetStartPlayersPositions()
        {           
            var dealerPlayer = _players.ElementAt(0);
            dealerPlayer.Position = Position.Dealer;
            SetBlindsPosition(dealerPlayer);
        }

        public void RandomPositionPlayers()
        {
            _players.Shuffle();
        }

        public void MoveDealerButton()
        {
            var dealerPlayer = GetDealer();
            dealerPlayer.Position = Position.None;
            var nextDealerPlayer = _players.NextOf(dealerPlayer);
            SetPlayerPosition(nextDealerPlayer, Position.Dealer);
            SetBlindsPosition(nextDealerPlayer);
        }

        private void SetBlindsPosition(Player dealerPlayer)
        {
            var nextSmallBlidPlayer = _players.NextOf(dealerPlayer);
            SetPlayerPosition(nextSmallBlidPlayer, Position.SmallBlind);
            if (_players.Count >= 3)
            {
                var nextBigBlindPlayer = _players.NextOf(nextSmallBlidPlayer);
                SetPlayerPosition(nextBigBlindPlayer, Position.BigBlind);
            }
        }

        private void SetPlayerPosition(Player player, Position position)
        {
            player.Position = position;
        }

        public Player GetDealer()
        {
            return _players.First(player => player.Position == Position.Dealer);
        }

        public Player SmallBlindPlayer()
        {
            return _players.First(player => player.Position == Position.SmallBlind);
        }

        public Player BigBlindPlayer()
        {
            return _players.First(player => player.Position == Position.BigBlind);
        }
    }
}
