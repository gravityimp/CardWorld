using CardConsole.Base.Interfaces;
using CardConsole.Games.Blackjack;
using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    public abstract class Environment
    {
        public IGame Game { get; protected set; }
        public GameType GameType { get; protected set; }
        public List<Agent> Agents { get; set; }
        public Dictionary<string, object> State { get { return Game.State; } }
        public int Decks { get; set; }

        public Environment(GameType gameType, List<Agent> agents)
        {
            Agents = agents;
            GameType = gameType;
            Decks = 1;
            Game = CreateGame(gameType, Decks);
        }

        public virtual Dictionary<string, object> Run()
        {
            if (Game.IsOver()) Game = CreateGame(GameType, Decks);
            Game.Start();

            while (!Game.IsOver())
            {
                Console.WriteLine(Utilities.DictionaryToString(State));

                string action = Game.GetCurrentPlayer().Step(Game.GetLegalActions());
                var state = Game.Step(action);

                Console.WriteLine(Utilities.DictionaryToString(state));
            }

            return Game.State;
        }

        protected virtual IGame CreateGame(GameType gameType, int decks = 1)
        {
            switch (gameType)
            {
                case GameType.Blackjack:
                    return new Games.Blackjack.Game(Agents, decks);
                default:
                    throw new ArgumentException("Unsupported game type");
            }
        }
    }
}
