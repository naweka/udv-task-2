namespace KolodAPI.DeckManager
{
    public interface IDeckManager
    {
        public void CreateDeck(string name);
        public void RemoveDeck(string name);
        public List<string> GetDeckNames();
        public void ShuffleDeck(string name);
        public Deck GetDeck(string name);
    }
}
