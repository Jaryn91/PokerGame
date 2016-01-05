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


        public void SmallBlindIntoPot(int amountOfSmallBlind, Pot pot)
        {
            Amount -= amountOfSmallBlind;
            pot.AddSmallBlind(amountOfSmallBlind);
        }

        public void BigBlindIntoPot(int amountOfBigBlind, Pot pot)
        {
            Amount -= amountOfBigBlind;
            pot.AddBigBlind(amountOfBigBlind);
        }

        public void AnteIntoPot(int ante, Pot pot)
        {
            Amount -= ante;
            pot.AddAnte(ante);
        }
    }
}
