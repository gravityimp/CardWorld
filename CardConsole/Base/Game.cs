using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    public abstract class Game<D, P>
        where D : Dealer, new()
        where P : Player, new()
    {
        private int _currentPlayer;

        public List<string> Actions { get; init; }
        public List<P> Players { get; protected set; }
        public D Dealer { get; init; }
        public Dictionary<string, object> State
        {
            get
            {
                Dictionary<string, object> state = new Dictionary<string, object>();
                state["legal_actions"] = GetLegalActions();
                state["actions"] = Actions;
                state["player"] = CurrentPlayer;
                state["player_cards"] = Players[CurrentPlayer].Cards;
                state["is_over"] = IsOver();

                return state;
            }
        }
        public int CurrentPlayer 
        {
            get {  return _currentPlayer; }
            protected set
            {
                _currentPlayer++;
                if (_currentPlayer == Players.Count()) _currentPlayer = 0;
            }
        }

        public Game()
        {
            Players = new List<P>();
            Dealer = new D { Decks = 1 };
            Dealer.Initialize();
        }

        public Game(List<Agent> agents, int decks = 1)
        {
            Players = new List<P>();
            for (int i = 0; i < agents.Count(); i++) 
            {
                Players.Add(new P() { Id = i, Agent = agents[i] });
            }
            Dealer = new D { Decks = decks };
            Dealer.Initialize();
        }

        public abstract void Configure(Dictionary<string, object> configuration);

        public abstract Dictionary<string, object> Start();

        public abstract Dictionary<string, object> Step(string action);

        public virtual bool IsOver()
        {
            foreach (P player in Players)
            {
                if (player.Status == PlayerStatus.Alive) return false; 
            }
            return true;
        }

        public virtual List<string> GetLegalActions()
        {
            return Actions;
        }

        protected virtual Dictionary<string, object> GetDefaultConfiguraiton(string game)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();

            using (StreamReader r = new StreamReader("game_conf.json"))
            {
                string json = r.ReadToEnd();
                var obj = (JsonObject)JsonObject.Parse(json)[game];

                foreach(var item in obj)
                {
                    config.Add(item.Key, item.Value);
                }
            }

            return config;
        }
    }
}
