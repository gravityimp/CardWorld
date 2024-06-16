using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CardConsole.Base
{
    internal abstract class Game
    {
        public string[] Actions { get; init; }
        public Player[] Players { get; protected set; }

        public abstract void Configure(Dictionary<string, object> configuration);
        public abstract void Start();
        public abstract void Step();
        public abstract State GetState();
        public abstract bool IsGameOver();

        protected Dictionary<string, object> GetDefaultConfiguraiton(string game)
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
