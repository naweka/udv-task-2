using FluentAssertions;
using KolodAPI.DeckManager;
using KolodAPI.Enums;

namespace KolodTests
{
    public class DeckTests
    {
        [Test]
        public void AddCard_SameCardAddedTwice_NotThrowsException()
        {
            var deck = new Deck();
            var card = new Card(CardSuit.Hearts, CardValue.Ace);

            deck.Cards.Add(card);

            Action action = () => deck.Cards.Add(new Card(CardSuit.Hearts, CardValue.Ace));
            action.Should().NotThrow();
        }

        [Test]
        public void Deck_CreatedWithDefaultConstructor_Has52Cards()
        {
            var deck = new Deck();

            deck.Cards.Should().HaveCount(52);
        }

        [Test]
        public void Deck_CreatedWithCustomList_HasCorrectNumberOfCards()
        {
            var cards = new List<Card>
        {
            new Card(CardSuit.Hearts, CardValue.Two),
            new Card(CardSuit.Spades, CardValue.Three),
            new Card(CardSuit.Clubs, CardValue.Four)
        };

            var deck = new Deck(cards);

            deck.Cards.Should().HaveCount(3);
        }
    }
}