using System.Collections.Generic;

namespace PokerCore.Beting.Blind.Standard
{
    public class StandardBigBlind : BigBlind
    {
        public StandardBigBlind()
        {
            Blinds = new Dictionary<int, int>
            {
                {1, 50},
                {2, 100},
                {3, 200},
                {4, 400},
                {5, 600},
                {6, 800},
                {7, 1000},
                {8, 1200},
                {9, 1400},
                {10, 2000}
            };
        }

    }

}
