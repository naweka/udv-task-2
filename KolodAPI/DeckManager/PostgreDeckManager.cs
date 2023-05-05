using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using KolodAPI.Models;
using System.Linq;
using KolodAPI.Shuffler;

namespace KolodAPI.DeckManager
{
    public class PostgreDeckManager : IDeckManager
    {
        private readonly DatabaseContext ctx;
        private readonly IDeckShuffler deckShuffler;

        private readonly JsonSerializerSettings jsonSerializerSettings =
            new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

        public PostgreDeckManager(
            DatabaseContext ctx,
            IDeckShuffler deckShuffler)
        {
            this.ctx = ctx;
            this.deckShuffler = deckShuffler;
        }

        public Deck CreateDeck(string name)
        {
            if (name.Length == 0)
                throw new ArgumentException("Invalid name");

            var deck = new Deck();
            var json = JsonConvert.SerializeObject(deck.Cards, jsonSerializerSettings);

            var model = new DeckModel()
            {
                Name = name,
                Deck = json
            };

            ctx.DecksTable.Add(model);
            ctx.SaveChanges();

            return deck;
        }

        public void EditDeck(string name, Deck newDeck)
        {
            if (!ctx.DecksTable.Any(d => d.Name == name))
                throw new ArgumentException($"Deck with name '{name}' does not exist");
            
            var deckModel = ctx.DecksTable.First(ctx=> ctx.Name == name);
            deckModel.Deck = JsonConvert.SerializeObject(newDeck.Cards, jsonSerializerSettings);
            ctx.SaveChanges();
        }

        public Deck GetDeck(string name)
        {
            if (!ctx.DecksTable.Any(d => d.Name == name))
                throw new ArgumentException($"Deck with name '{name}' does not exist");

            var deckModel = ctx.DecksTable.First(ctx => ctx.Name == name);
            var cards = JsonConvert.DeserializeObject<List<Card>>(deckModel.Deck!);
            return new Deck(cards!);
        }

        public List<string> GetDeckNames()
        {
            return ctx.DecksTable.Select(d => d.Name!).ToList();
        }

        public void RemoveDeck(string name)
        {
            if (!ctx.DecksTable.Any(d => d.Name == name))
                throw new ArgumentException($"Deck with name '{name}' does not exist");

            var deckModel = ctx.DecksTable.First(ctx => ctx.Name == name);
            ctx.DecksTable.Remove(deckModel);
            ctx.SaveChanges();
        }

        public void ShuffleDeck(string name)
        {
            if (!ctx.DecksTable.Any(d => d.Name == name))
                throw new ArgumentException($"Deck with name '{name}' does not exist");

            var deckModel = ctx.DecksTable.First(ctx => ctx.Name == name);
            var cards = JsonConvert.DeserializeObject<List<Card>>(deckModel.Deck!);

            var deck = new Deck(deckShuffler.GetShuffledDeck(cards!));

            deckModel.Deck = JsonConvert.SerializeObject(deck.Cards, jsonSerializerSettings);
            ctx.SaveChanges();
        }
    }
}
