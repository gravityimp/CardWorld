using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardConsole.Utils;

namespace CardConsole.Base
{
    public abstract class Player
    {
        public int Id { get; init; }
        public Agent Agent { get; init; }
        public PlayerStatus Status { get; set; }
        public List<string> Cards { get; set; }

        public Player()
        {
            this.Status = PlayerStatus.Alive;
            this.Cards = new List<string>();
        }

        public string Step(List<string> legalActions)
        {
            return Agent.Step(legalActions);
        }
    }
}
