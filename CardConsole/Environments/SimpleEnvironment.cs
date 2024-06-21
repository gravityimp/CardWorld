using CardConsole.Base;
using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Environments
{
    public class SimpleEnvironment : Base.Environment
    {
        public SimpleEnvironment(GameType gameType, List<Agent> agents) : base(gameType, agents) { }
    }
}
