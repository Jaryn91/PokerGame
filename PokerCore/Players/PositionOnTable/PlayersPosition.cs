using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.Players.PositionOnTable
{
    public class PlayersPosition
    {

        public void SetStartPlayersPositions(List<Player> players)
        {           
            var dealerPlayer = players.ElementAt(0);
            dealerPlayer.Position = Position.Dealer;
            SetBlindsPosition(players, dealerPlayer);
        }

        public void RandomPositionPlayers(List<Player> players)
        {
            players.Shuffle();
        }

        public void MoveDealerButton(List<Player> players)
        {
            var dealerPlayer = GetDealer(players);
            dealerPlayer.Position = Position.None;
            var nextDealerPlayer = players.NextOf(dealerPlayer);
            SetPlayerPosition(nextDealerPlayer, Position.Dealer);
            SetBlindsPosition(players, nextDealerPlayer);
        }

        private void SetBlindsPosition(List<Player> players, Player dealerPlayer)
        {
            var nextSmallBlidPlayer = players.NextOf(dealerPlayer);
            SetPlayerPosition(nextSmallBlidPlayer, Position.SmallBlind);
            if (players.Count >= 3)
            {
                var nextBigBlindPlayer = players.NextOf(nextSmallBlidPlayer);
                SetPlayerPosition(nextBigBlindPlayer, Position.BigBlind);
            }
        }

        private void SetPlayerPosition(Player player, Position position)
        {
            player.Position = position;
        }

        public Player GetDealer(List<Player> players)
        {
            return players.First(player => player.Position == Position.Dealer);
        }

        public Player SmallBlindPlayer(List<Player> players)
        {
            return players.First(player => player.Position == Position.SmallBlind);
        }

        public Player BigBlindPlayer(List<Player> players)
        {
            return players.First(player => player.Position == Position.BigBlind);
        }
    }
}
