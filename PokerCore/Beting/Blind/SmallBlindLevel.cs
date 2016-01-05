using System.Collections.Generic;

namespace PokerCore.Beting.Blind
{
    public class SmallBlindLevel
    {
        private readonly List<int> _blinds = new List<int>
        {
            0, 25, 50, 100, 200, 300, 400, 500, 600, 700, 1000
        };

        public int GetValueFromLevel(int level)
        {
            return _blinds[level];
        }
    }
}
