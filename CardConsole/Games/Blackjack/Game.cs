using CardConsole.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseGame = CardConsole.Base.Game;

namespace CardConsole.Games.Blackjack
{
    internal class Game : BaseGame
    {

        public Game() 
        {
            Actions = ["stand", "hit"];
        }

        public Game(Player[] players) : this()
        {
            Players = players;
        }

        public override void Configure(Dictionary<string, object> configuration)
        {
            Dictionary<string, object> _default = GetDefaultConfiguraiton("blackjack");
            Players = new Player[configuration.ContainsKey("players") ? Convert.ToInt32(configuration["players"]) : Convert.ToInt32(_default["players"])];

        }

        public override Base.State GetState()
        {
            throw new NotImplementedException();
        }

        public override bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
