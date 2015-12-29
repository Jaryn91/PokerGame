using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCore.Beting
{
    public class Chips
    {
        public int Amount { get; private set; }

        public Chips(int startAmount)
        {
            Amount = startAmount;
        }

        public int Bet(int amountOfBet)
        {
            Amount =- amountOfBet;
            return amountOfBet;
        }

        public void Win(int amountOfWin)
        {
            Amount = +amountOfWin;
        }
    }
}
