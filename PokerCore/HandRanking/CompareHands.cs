using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.HandRanking
{
    public class CompareHands
    {
        private List<Card> _firstHand;
        private List<Card> _secondHand;

        public CompareHands(List<Card> firstHand, List<Card> secondHand)
        {
            _firstHand = firstHand;
            _secondHand = secondHand;
        }

        public ResultsOfCompareHands Compare()
        {
            var firstHand = new EvaluateHand(_firstHand);
            var powerOfFirstHand = firstHand.Evaluate();
            var secondHand = new EvaluateHand(_secondHand);
            var powerOfSecondHand = secondHand.Evaluate();
            if (FirstPlayerHasBiggerPowerOfHand(powerOfFirstHand, powerOfSecondHand))
                return ResultsOfCompareHands.WinFirstPlayer;
            else if (SecondPlayerHasBiggerPowerOfHand(powerOfFirstHand, powerOfSecondHand))
                return ResultsOfCompareHands.WinSecondPlayer;

            return CompareHandsWithSamePower(firstHand, secondHand);

            
        }

        private bool SecondPlayerHasBiggerPowerOfHand(PowerOfHand powerOfFirstHand, PowerOfHand powerOfSecondHand)
        {
            return (int)powerOfFirstHand < (int)powerOfSecondHand;
        }

        private bool FirstPlayerHasBiggerPowerOfHand(PowerOfHand powerOfFirstHand, PowerOfHand powerOfSecondHand)
        {
            return (int) powerOfFirstHand > (int) powerOfSecondHand;
        }

        private ResultsOfCompareHands CompareHandsWithSamePower(EvaluateHand firstEvaluateHand, EvaluateHand secondEvaluateHand)
        {
            var firstHand = firstEvaluateHand.GetHand(); 
            var secondHand = secondEvaluateHand.GetHand();
            return firstHand.Compare(secondHand);
        }
    }
}
