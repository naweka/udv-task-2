using KolodAPI.Enums;

namespace KolodAPI.DeckManager
{
    public class Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Card otherCard = (Card)obj;
            return Suit == otherCard.Suit && Value == otherCard.Value;
        }
    }
}
