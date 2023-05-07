using KolodAPI.Shuffler;

namespace KolodAPI.DeckManager
{
    public class MemoryDeckManager : IDeckManager
    {
        private readonly Dictionary<string, Deck> _decks;
        private readonly IDeckShuffler deckShuffler;

        public MemoryDeckManager(IDeckShuffler deckShuffler)
        {
            _decks = new Dictionary<string, Deck>();
            this.deckShuffler = deckShuffler;
        }

        public Deck CreateDeck(string name)
        {
            if (_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' already exists");
            }

            var deck = new Deck();
            _decks.Add(name, deck);

            return deck;
        }

        public void RemoveDeck(string name)
        {
            if (!_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            }

            _decks.Remove(name);
        }

        public List<string> GetDeckNames()
        {
            return new List<string>(_decks.Keys);
        }

        public void ShuffleDeck(string name)
        {
            if (!_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            }

            _decks[name].SetCards(deckShuffler.GetShuffledDeck(_decks[name].Cards));
        }

        public Deck GetDeck(string name)
        {
            if (!_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            }

            return _decks[name];
        }

        public void EditDeck(string name, Deck deck)
        {
            if (!_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            }

            _decks[name] = deck;
        }
    }
}
