using System.Collections.Generic;

namespace PokerCore.Beting.Blind.Standard
{
    public class StandardSmallBlind : SmallBlind
    {
        public StandardSmallBlind()
        {
            Blinds = new Dictionary<int, int>
            {
                {1, 25},
                {2, 50},
                {3, 100},
                {4, 200},
                {5, 300},
                {6, 400},
                {7, 500},
                {8, 600},
                {9, 700},
                {10, 1000}
            };
        }
    }
}
