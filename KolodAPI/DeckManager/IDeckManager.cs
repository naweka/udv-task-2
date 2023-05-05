namespace KolodAPI.DeckManager
{
    public interface IDeckManager
    {
        public Deck CreateDeck(string name);
        public void RemoveDeck(string name);
        public void EditDeck(string name, Deck deck);
        public List<string> GetDeckNames();
        public void ShuffleDeck(string name);
        public Deck GetDeck(string name);
    }
}
