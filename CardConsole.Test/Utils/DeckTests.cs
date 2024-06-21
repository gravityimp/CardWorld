using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Test.Utilities
{
    public class DeckTests
    {
        [Fact]
        public void Deck_GetDeck_ReturnCards()
        {
            var deck = CardConsole.Utils.Deck.GetDeck();

            Assert.NotEmpty(deck);
            Assert.Equal(52, deck.Count());
        }
    }
}
