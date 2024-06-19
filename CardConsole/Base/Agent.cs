using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    public abstract class Agent
    {
        public abstract string Step(List<string> legalActions); 
    }
}
