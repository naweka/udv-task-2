using KolodAPI.DeckManager;

namespace KolodAPI.Shuffler
{
    public interface IDeckShuffler
    {
        public List<Card> GetShuffledDeck(List<Card> cards);
    }
}
