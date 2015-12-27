using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.HandRanking
{
    public enum PowerOfHand
    {
        HightCard = 0,
        Pair = 1,
        TwoPairs = 2,
        ThreeOfKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfKind = 7,
        StraightFlush = 8
    }
}
