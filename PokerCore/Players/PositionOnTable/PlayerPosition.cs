using PokerCore.Table;

namespace PokerCore.Players.PositionOnTable
{
    public class PlayerPosition
    {
        public Player Player;
        public Position Position;

        public PlayerPosition(Player player)
        {
            Player = player;
        }

        public PlayerPosition(Player player, Position position)
        {
            Player = player;
            Position = position;
        }
    }
}
