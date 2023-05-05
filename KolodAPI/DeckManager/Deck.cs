using KolodAPI.Enums;
using KolodAPI.Shuffler;
using System;

namespace KolodAPI.DeckManager
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Cards.Add(new Card(suit, value));
                }
            }
        }

        public Deck(List<Card> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            return $"Deck of {Cards.Count} cards";
        }
    }
}
