using PokerCore.DeckOfCards;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PokerCore.HandRanking
{
    public class HighCard : CheckHand
    {
        public HighCard(List<Card> cards)
        {
            _cards = cards;
        }

        public HighCard()
        {
        }

        public override bool Check()
        {
            _cards = GetTheHighestCards(_cards, PokerRules.CardsToCreateHand);
            return true;
        }

        private List<Card> GetTheHighestCards(List<Card> cards, int numberOfBestCards)
        {
            return cards.OrderByDescending(c => c.Figure).Take(numberOfBestCards).ToList();
        }

        public List<Card> GetWinningCards()
        {
            return _cards;
        }

        public override ResultsOfCompareHands Compare(CheckHand secondCheckHand)
        {
            var secondHand = (HighCard)secondCheckHand;
            var secondHandCards = secondHand.GetWinningCards();
            for (var i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].Figure > secondHandCards[i].Figure)
                    return ResultsOfCompareHands.WinFirstPlayer;
                else if (_cards[i].Figure < secondHandCards[i].Figure)
                    return ResultsOfCompareHands.WinSecondPlayer;
            }
            return ResultsOfCompareHands.Draw;
        }

        public ResultsOfCompareHands Compare(List<Card> firstHand, List<Card> secondHand, int cardsToCompare)
        {
            var theHighestCardsFromFirstHand = GetTheHighestCards(firstHand, cardsToCompare);
            var theHighestCardsFromSecondHand = GetTheHighestCards(secondHand, cardsToCompare);
            for (var i = 0; i < cardsToCompare; i++)
            {
                if (theHighestCardsFromFirstHand[i].Figure > theHighestCardsFromSecondHand[i].Figure)
                    return ResultsOfCompareHands.WinFirstPlayer;
                else if (theHighestCardsFromFirstHand[i].Figure < theHighestCardsFromSecondHand[i].Figure)
                    return ResultsOfCompareHands.WinSecondPlayer;
            }
            return ResultsOfCompareHands.Draw;
        }
    }
}
