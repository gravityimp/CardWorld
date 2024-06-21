using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Agents
{
    internal class RandomAgent : Base.Agent
    {
        Random Random { get; init; }
        
        public RandomAgent(int? seed = null)
        {
            Random = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public override string Step(List<string> legalActions)
        {
            return legalActions[Random.Next(legalActions.Count())];
        }
    }
}
