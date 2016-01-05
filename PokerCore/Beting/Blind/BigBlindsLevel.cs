using System.Collections.Generic;

namespace PokerCore.Beting.Blind
{
    public class BigBlindsLevel
    {
        private readonly List<int> _blinds = new List<int>
        {
            0, 50, 100, 200, 400, 600, 800, 1000, 1200, 1400, 2000
        };

        public int GetValueFromLevel(int level)
        {
            return _blinds[level];
        }
    }
}
