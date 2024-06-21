using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Base.Interfaces
{
    public interface IGame
    {
        public List<string> Actions { get; init; }
        public Dictionary<string, object> State { get; }
        
        public abstract Dictionary<string, object> Start();
        public abstract Dictionary<string, object> Step(string action);
        public bool IsOver();
        public List<string> GetLegalActions();
        public Player GetCurrentPlayer();  
    }
}
