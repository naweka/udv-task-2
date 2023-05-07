using FluentAssertions;
using KolodAPI.DeckManager;
using KolodAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolodTests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void TestToString()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Jack);
            card.ToString().Should().Be("Jack of Hearts");
        }

        [Test]
        public void TestEquals()
        {
            var card1 = new Card(CardSuit.Spades, CardValue.Ten);
            var card2 = new Card(CardSuit.Spades, CardValue.Ten);
            var card3 = new Card(CardSuit.Diamonds, CardValue.Three);

            card1.Should().Be(card2);
            card1.Should().NotBe(card3);
        }
    }
}
