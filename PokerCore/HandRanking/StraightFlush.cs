using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.HandRanking
{
    public class StraightFlush : CheckHand
    {
        public int StartValue { get; private set; }
        public StraightFlush(List<Card> cards)
        {
            _cards = cards;
        }


        public override bool Check()
        {
            var flush = new Flush(_cards);
            if (flush.Check())
            {
                var flushCards = flush.GetAllFlushCards();
                var straight = new Straight(flushCards);
                if (straight.Check())
                {
                    StartValue = straight.EndValue;
                    return true;
                }
            }
            return false;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (StraightFlush)secondCheckHand;
            var secondStartValue = secondHand.StartValue;
            if (ThisFigureWins(secondStartValue))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (OtherFigureWins(secondStartValue))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private bool OtherFigureWins(int secondStartValue)
        {
            return StartValue < secondStartValue;
        }

        private bool ThisFigureWins(int secondStartValue)
        {
            return StartValue > secondStartValue;
        }
    }
}
