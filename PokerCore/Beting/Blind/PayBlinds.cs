using System.Collections.Generic;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Beting.Blind
{
    public class PayBlinds
    {
        private Pot _pot;
        private int _blindLevel;
        private List<Player> _players;
        private Blinds _blinds;



        public PayBlinds(List<Player> players, int blindLevel, Pot pot, Blinds blinds)
        {
            _players = players;
            _blindLevel = blindLevel;
            _pot = pot;
            _blinds = blinds;
        }

        public void GetBlinds()
        {
            var positionOnTable = new PlayersPosition(_players);
            var smallBlind = positionOnTable.SmallBlindPlayer();
            var bigBlind = positionOnTable.BigBlindPlayer();
            GetSmallBlindFromPlayers(smallBlind);
            GetBigBlindFromPlayers(bigBlind);
            GetAnteFromPlayers(_players);
        }

        private void GetAnteFromPlayers(List<Player> players)
        {
            Ante ante = _blinds.Ante;
            var amountOfChipsAnte = ante.GetValueFromLevel(_blindLevel);
            foreach (var player in players)
            {
                player.PayAnte(amountOfChipsAnte, _pot);
            }
        }

        private void GetBigBlindFromPlayers(Player bigBlindPlayer)
        {
            BigBlind bigBlind = _blinds.BigBlind;
            var amountOfChipsBigBlind = bigBlind.GetValueFromLevel(_blindLevel);
            bigBlindPlayer.PayBigBlind(amountOfChipsBigBlind, _pot);
        }

        private void GetSmallBlindFromPlayers(Player smallBlindPlayer)
        {
            SmallBlind smallBlind = _blinds.SmallBlind;
            var amountOfSmallBlindChips = smallBlind.GetValueFromLevel(_blindLevel);
            smallBlindPlayer.PaySmallBlind(amountOfSmallBlindChips, _pot);
        }
    }
}
