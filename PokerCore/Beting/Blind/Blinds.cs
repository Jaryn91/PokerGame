using System.Collections.Generic;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Beting.Blind
{
    public class Blinds
    {
        private Pot _pot;
        private int _actualLevelOfBlinds;
        private List<Player> _players;
        private SmallBlindLevel _smallBlindLevel;
        private BigBlindsLevel _bigBlindLevel;
        private AnteLevel _anteLevel;

        public Blinds(List<Player> players, int actualLevelOfBlinds, Pot pot,
            SmallBlindLevel smallBlindLevel, BigBlindsLevel bigBlindsLevel,
            AnteLevel anteLevel)
        {
            _players = players;
            _actualLevelOfBlinds = actualLevelOfBlinds;
            _pot = pot;
            _smallBlindLevel = smallBlindLevel;
            _bigBlindLevel = bigBlindsLevel;
            _anteLevel = anteLevel;
        }

        public void GetBlinds()
        {
            var positionOnTable = new PlayersPosition();
            var smallBlind = positionOnTable.SmallBlindPlayer(_players);
            var bigBlind = positionOnTable.BigBlindPlayer(_players);
            GetSmallBlindFromPlayers(smallBlind);
            GetBigBlindFromPlayers(bigBlind);
            GetAnteFromPlayers();
        }

        private void GetAnteFromPlayers()
        {
            var amountOfChipsAnte = _anteLevel.GetValueFromLevel(_actualLevelOfBlinds);
            foreach (var player in _players)
            {
                player.PayAnte(amountOfChipsAnte, _pot);
            }
        }

        private void GetBigBlindFromPlayers(Player bigBlindPlayer)
        {
            var amountOfChipsBigBlind = _bigBlindLevel.GetValueFromLevel(_actualLevelOfBlinds);
            bigBlindPlayer.PayBigBlind(amountOfChipsBigBlind, _pot);
        }

        private void GetSmallBlindFromPlayers(Player smallBlindPlayer)
        {
            var amountOfSmallBlindChips = _smallBlindLevel.GetValueFromLevel(_actualLevelOfBlinds);
            smallBlindPlayer.PaySmallBlind(amountOfSmallBlindChips, _pot);
        }
    }
}
