using CardConsole.Agents;
using CardConsole.Base;
using CardConsole.Environments;
using CardConsole.Games.Blackjack;
using CardConsole.Utils;

List<Agent> agents = new List<Agent>() { new PlayerAgent(), new RandomAgent() };
var env = new SimpleEnvironment(GameType.Blackjack, agents);
env.Run();