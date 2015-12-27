using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerCore.DeckOfCards;
using PokerCore.Players;
namespace PokerCore.Dealing
{
    public class DealPocketCards
    {
        private List<Player> _players;
        private Deck _deck; 
        public DealPocketCards(List<Player> players, Deck deck)
        {
            _players = players;
            _deck = deck;
        }

        public void Deal()
        {
            for (var i = 0; i < PokerRules.PocketCards; i++)
            {
                foreach (var player in _players)
                {
                    var card = _deck.TakeCard();
                    player.AddPocketCard(card);
                }
            }
        }



    }
}
