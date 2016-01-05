using System;
using System.Collections.Generic;
using PokerCore.Beting;
using PokerCore.Beting.Blind;
using PokerCore.Dealing;
using PokerCore.DeckOfCards;
using PokerCore.Players;
using PokerCore.Players.PositionOnTable;

namespace PokerCore.Table
{
    public class PlayHandOnTable
    {      
        public CardsOnTable TableCards { get; private set; }
        public Pot Pot { get; private set; }

        public List<Player> Players { get; private set; }
        private readonly Deck _deck;
        private readonly int _blindLevel;
        private readonly Blinds _blinds;
        
        public PlayHandOnTable(List<Player> players, Blinds blinds, int blindLevel)
        {
            Players = players;
            _blinds = blinds;
            _blindLevel = blindLevel;
            TableCards = new CardsOnTable();
            _deck = new Deck();
            Pot = new Pot();
        }

        public void PreFlop()
        {
            _deck.Shuffle();
            var blinds = new PayBlinds(Players, _blindLevel, Pot, _blinds);
            var dealPocketCards = new DealPocketCards(Players, _deck);
            dealPocketCards.Deal();
            var preFlopGame = new PreFlopGame(Players, Pot, _blinds);
            
        }

        public void PutFlopOnTable()
        {
            var dealFlop = new DealTableCardsFlop(_deck);
            var flopCards = dealFlop.Deal();
            TableCards.FlopCards = flopCards;
        }

        public void PutTurnOnTable()
        {          
            var dealTurn = new DealTableCardsTurn(_deck);
            var turnCards = dealTurn.Deal();
            TableCards.TurnCards = turnCards;
        }

        public void PutRiverOnTable()
        {   
            var dealRiver = new DealTableCardsRiver(_deck);
            var riverCards = dealRiver.Deal();
            TableCards.RiverCards = riverCards;
        }


        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
