using System.Collections.Generic;

namespace PokerCore.Beting.Blind
{
    public class AnteLevel
    {
        private readonly List<int> _ante = new List<int>
        {
            0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 100
        };

        public int GetValueFromLevel(int level)
        {
            return _ante[level];
        }
    }
}
