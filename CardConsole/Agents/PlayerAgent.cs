using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Agents
{
    internal class PlayerAgent : Base.Agent
    {
        public override string Step(List<string> legalActions)
        {
            string action = "";
            while (!legalActions.Contains(action))
            {
                Console.WriteLine($"Choose action {Utilities.ListToString(legalActions)}:");
                action = Console.ReadLine();
            }
            return action;
        }
    }
}
