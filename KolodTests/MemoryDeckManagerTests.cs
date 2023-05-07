using FluentAssertions;
using KolodAPI.DeckManager;
using KolodAPI.DeckShuffler;

namespace KolodTests
{
    [TestFixture]
    public class MemoryDeckManagerTests
    {
        [Test]
        public void ShuffleExistingDeck_Success()
        {
            var deckManager = new MemoryDeckManager(new SimpleDeckShuffler());
            var deck = deckManager.CreateDeck("Existing Deck");
            var cardBefore = deck.Cards.ElementAt(1);

            deckManager.ShuffleDeck("Existing Deck");

            var cardAfter = deck.Cards.ElementAt(1);

            cardBefore.Should().NotBe(cardAfter);
        }

        [Test]
        public void CreateNewDeckWithUniqueName_Success()
        {
            var deckManager = new MemoryDeckManager(new SimpleDeckShuffler());

            var resultDeck = deckManager.CreateDeck("New Deck");

            resultDeck.Should().NotBeNull();
            deckManager.GetDeckNames().Should().HaveCount(1).And.Contain("New Deck");
        }

        [Test]
        public void CreateNewDeckWithExistingName_ThrowsArgumentException()
        {
            var deckManager = new MemoryDeckManager(new SimpleDeckShuffler());
            deckManager.CreateDeck("Existing Deck");

            Action act = () => deckManager.CreateDeck("Existing Deck");
            act.Should().Throw<ArgumentException>()
                .WithMessage("Deck with name 'Existing Deck' already exists");
        }

        [Test]
        public void RemoveExistingDeck_Success()
        {
            var deckManager = new MemoryDeckManager(new SimpleDeckShuffler());
            deckManager.CreateDeck("Existing Deck");

            deckManager.RemoveDeck("Existing Deck");

            deckManager.GetDeckNames().Should().BeEmpty();
        }
    }
}
