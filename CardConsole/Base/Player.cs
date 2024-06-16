using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    internal abstract class Player
    {
        public int Id { get; init; }
        public PlayerStatus Status { get; set; }
        public List<string> Cards { get; set; }

        public Player() { }
    }
}
