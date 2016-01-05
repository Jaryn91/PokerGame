using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.Beting
{
    public class Pot
    {
        public int Amount { get; private set; }

        public Pot()
        {
            Amount = 0;
        }
        public void AddSmallBlind(int smallBlind)
        {
            Amount += smallBlind;
        }

        public void AddBigBlind(int bigBlind)
        {
            Amount += bigBlind;
        }

        public void AddAnte(int ante)
        {
            Amount += ante;
        }
    }
}
