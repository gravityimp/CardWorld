using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Utils
{
    public static class Deck
    {
        public static List<string> GetDeck(bool shuffled)
        {
            string[] symbols = ["S", "H", "D", "C"];
            List<string> cards = new List<string>();

            foreach (string symbol in symbols)
            {
                for(int i = 2; i <= 10; i++)
                {
                    cards.Add($"{symbol}{i}");
                }
                cards.Add($"{symbol}J");
                cards.Add($"{symbol}Q");
                cards.Add($"{symbol}K");
                cards.Add($"{symbol}A");
            }
            return cards;
        }
    }
}