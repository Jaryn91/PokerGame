using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.Beting.Blind
{
    public class Blinds
    {
        public SmallBlind SmallBlind { get; private set; }
        public BigBlind BigBlind { get; private set; }
        public Ante Ante { get; private set; }

        public Blinds(BigBlind bigBlind, SmallBlind smallBlind, Ante ante)
        {
            BigBlind = bigBlind;
            SmallBlind = smallBlind;
            Ante = ante;
        }

        
    }
}
