using System.Collections.Generic;

namespace PokerCore.Beting.Blind
{
    public abstract class BigBlind
    {
        protected Dictionary<int, int> Blinds;

        public int GetValueFromLevel(int level)
        {
            return Blinds[level];
        }
    }
}
