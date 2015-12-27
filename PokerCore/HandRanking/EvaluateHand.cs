using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;

namespace PokerCore.HandRanking
{
    public class EvaluateHand
    {
        private List<Card> _cards;
        private CheckHand _checkHand;

        public EvaluateHand(List<Card> cards)
        {
            _cards = cards;
        }

        public PowerOfHand Evaluate()
        {
            _checkHand = new StraightFlush(_cards);
            if (_checkHand.Check())
                return PowerOfHand.StraightFlush;

            _checkHand = new FourOfKind(_cards);
            if(_checkHand.Check())
                return PowerOfHand.FourOfKind;

            _checkHand = new FullHouse(_cards);
            if(_checkHand.Check())
                return PowerOfHand.FullHouse;

            _checkHand = new Flush(_cards);
            if (_checkHand.Check())
                return PowerOfHand.Flush;

            _checkHand = new Straight(_cards);
            if(_checkHand.Check())
                return  PowerOfHand.Straight;

            _checkHand = new ThreeOfKind(_cards);
            if(_checkHand.Check())
                return PowerOfHand.ThreeOfKind;

            _checkHand = new TwoPairs(_cards);
            if(_checkHand.Check())
                return PowerOfHand.TwoPairs;

            _checkHand = new Pair(_cards);
            if(_checkHand.Check())
                return  PowerOfHand.Pair;

            _checkHand = new HighCard(_cards);
            return PowerOfHand.HightCard;
        }

        public CheckHand GetHand()
        {
            return _checkHand;
        }
    }

    
}
