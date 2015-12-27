namespace PokerCore.DeckOfCards
{
    public class Card
    {
        public CardFigure Figure { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFigure figure, CardSuit suit)
        {
            Figure = figure;
            Suit = suit;
        }
    }
}
