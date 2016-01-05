using System.Collections.Generic;

namespace PokerCore.Beting.Blind
{
    public abstract class Ante
    {
        protected Dictionary<int, int> BlindAnte;

        public int GetValueFromLevel(int level)
        {
            return BlindAnte[level];
        }
    }
}
