using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore.HandRanking
{
    public class Straight : CheckHand
    {

        public int EndValue { get; private set; }
        public Straight(List<Card> cards)
        {
            _cards = cards;
        }

        public override bool Check()
        {
            var distinceFigures = DistinctFigures();
            var valuesOfFigures = GetValuesOfFigures(distinceFigures);
            var orderedValues = OrderValueOfFigures(valuesOfFigures);
            return ExistSequencOfFiveCards(orderedValues);
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (Straight) secondCheckHand;
            var secondStartValue = secondHand.EndValue;
            if (ThisFigureWins(secondStartValue))
                return ResultsOfCompareHands.WinFirstPlayer;

            if (OtherFigureWins(secondStartValue))
                return ResultsOfCompareHands.WinSecondPlayer;

            return ResultsOfCompareHands.Draw;
        }

        private bool OtherFigureWins(int secondStartValue)
        {
            return EndValue < secondStartValue;
        }

        private bool ThisFigureWins(int secondStartValue)
        {
            return EndValue > secondStartValue;
        }

        private bool ExistSequencOfFiveCards(List<int> valuesOfFigures)
        {
            int count = 0;
            int firstItem = 0; // Irrelevant to start with
            foreach (int num in valuesOfFigures)
            {
                // First value in the ordered list: start of a sequence
                if (count == 0)
                {
                    firstItem = num;
                    count = 1;
                }
                // New value contributes to sequence
                else if (num == firstItem + count)
                {
                    count++;
                }
                // If straight
                else if (count >= 5)
                {
                    EndValue = firstItem + 4;
                    break;
                }
                // End of one sequence, start of another
                else
                {
                    count = 1;
                    firstItem = num;
                }
            }

            if (count >= 5)
            {
                EndValue = firstItem + 4;
                return true;
            }
            else
                return false;
        }
        private List<int> GetValuesOfFigures(List<CardFigure> distinceFigures)
        {
            var ints = distinceFigures.Select(cf => (int)cf).ToList();
            if (distinceFigures.Contains(CardFigure.Ace))
                ints.Add(1);
            return ints;
        }

        private List<CardFigure> DistinctFigures()
        {            
            var figures = _cards.Select(c => c.Figure).ToList();
            var distinctedFigures = figures.Distinct().ToList();
            return distinctedFigures;
        }

        public int GetStartValue()
        {
            return EndValue;
        }

        private bool IsConsecutive(List<int> intList)
        {
            return intList.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        private List<int> OrderValueOfFigures(List<int> valuesOfFigures)
        {
            return valuesOfFigures.OrderBy(c => c).ToList();
        }
    }
}
