using CardConsole.Agents;
using CardConsole.Base;
using CardConsole.Games.Blackjack;
using CardConsole.Utils;
using BlackjackGame = CardConsole.Games.Blackjack.Game;

List<Agent> agents = new List<Agent>() { new PlayerAgent() };
var game = new BlackjackGame(agents, 1);
var state = game.Start();
Console.WriteLine(Utilities.DictionaryToString(state));

while (!game.IsOver())
{
    int player = game.CurrentPlayer;
    string action = game.Players[game.CurrentPlayer].Step(game.GetLegalActions());
    state = game.Step(action);
    Console.WriteLine($"Players score: {Judge.JudgePlayer(game.Players[player])}");
    Console.WriteLine($"Dealers score: {Judge.JudgeDealer(game.Dealer)}");
    Console.WriteLine(Utilities.DictionaryToString(state));
}

Console.WriteLine(Utilities.DictionaryToString(game.State));