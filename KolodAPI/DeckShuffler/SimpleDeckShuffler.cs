using KolodAPI.DeckManager;
using KolodAPI.Shuffler;

namespace KolodAPI.DeckShuffler
{
    public class SimpleDeckShuffler : IDeckShuffler
    {
        private readonly Random random = new();
        public List<Card> GetShuffledDeck(List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (cards[k], cards[n]) = (cards[n], cards[k]);
            }

            return cards;
        }
    }
}
