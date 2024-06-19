using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Games.Blackjack
{
    public class Dealer : Base.Dealer
    {
        public List<string> Visible { get; set; }
        public string Hidden { get; set; }

        public Dealer() : base()
        {
            Visible = new List<string>();
            Hidden = "";
        }
    }
}
