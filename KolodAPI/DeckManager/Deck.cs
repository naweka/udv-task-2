using KolodAPI.Enums;
using KolodAPI.Shuffler;
using System;

namespace KolodAPI.DeckManager
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }


        public void AddCard(Card card)
        {
            if (!Cards.Contains(card))
                Cards.Add(card);
            else
                throw new InvalidOperationException($"Card {card} already exist");
        }

        public void SetCards(List<Card> newCards)
        {
            Cards = newCards;
        }

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
            Cards = cards;
        }

        public override string ToString()
        {
            return $"Deck of {Cards.Count} cards";
        }
    }
}
