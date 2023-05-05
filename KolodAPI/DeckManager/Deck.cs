using KolodAPI.Enums;
using System;

namespace KolodAPI.DeckManager
{
    public class Deck
    {
        private readonly List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();


            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    _cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();

            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (_cards[k], _cards[n]) = (_cards[n], _cards[k]);
            }
        }

        public IReadOnlyList<Card> Cards => _cards;

        public override string ToString()
        {
            return $"Deck of {_cards.Count} cards";
        }
    }
}
