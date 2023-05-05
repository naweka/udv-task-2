namespace KolodAPI.DeckManager
{
    public class DeckManager : IDeckManager
    {
        private readonly Dictionary<string, Deck> _decks;

        public DeckManager()
        {
            _decks = new Dictionary<string, Deck>();
        }

        public void CreateDeck(string name)
        {
            if (_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' already exists");
            }

            _decks.Add(name, new Deck());
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

            _decks[name].Shuffle();
        }

        public Deck GetDeck(string name)
        {
            if (!_decks.ContainsKey(name))
            {
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            }

            return _decks[name];
        }
    }
}
