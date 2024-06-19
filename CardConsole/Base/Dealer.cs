using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    public abstract class Dealer
    {
        public Stack<string> Cards { get; protected set; }
        public int Decks { get; init; }

        public Dealer()
        {
            Cards = new Stack<string>();
        }

        public virtual void Initialize()
        {
            for (int i = 0; i < Decks; i++)
            {
                Cards = new Stack<string>(Cards.Concat(Deck.GetDeck()));
            }
            Shuffle();
        }
        
        public virtual string Deal()
        {
            return Cards.Pop();
        }

        private void Shuffle()
        {
            Random random = new Random();
            List<string> cardsList = Cards.OrderBy(x => random.Next()).ToList();
            Cards = new Stack<string>(cardsList);
        }
    }
}
