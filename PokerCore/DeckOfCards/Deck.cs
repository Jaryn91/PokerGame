﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerCore.DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        public Deck()
        {
            Cards = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardFigure figure in Enum.GetValues(typeof(CardFigure)))
                {
                    var card = new Card(figure, suit);
                    Cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            var rng = new Random();

            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var card = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = card;
            }
        }

        public Card TakeCard()
        {
            var card = Cards.Take(1).First();
            Cards.Remove(card);
            return card;
        }
    }
}
