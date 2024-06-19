using CardConsole.Base;
using CardConsole.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Games.Blackjack
{
    internal class Game : Base.Game<Dealer, Player>
    {
        public new Dictionary<string, object> State
        {
            get
            {
                Dictionary<string, object> state = base.State;
                state["dealer_cards"] = Dealer.Visible;

                if (IsOver())
                {
                    state["rewards"] = Judge.JudgeGame(this);
                }

                return state;
            }
        }

        public Game(List<Agent> agents, int decks = 1) : base(agents, decks) 
        {
            Actions = new List<string> { "stand", "hit" };
        }

        public override void Configure(Dictionary<string, object> configuration)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> Start()
        {
            // Check if the game has already started
            if (Dealer.Hidden != string.Empty) return State;

            // Deal the cards to the players and a dealer
            for (int i = 0; i < 2; i++)
            {
                foreach (var player in Players)
                {
                    player.Cards.Add(Dealer.Deal());
                }
                if (Dealer.Visible.Count() == 0) Dealer.Visible.Add(Dealer.Deal());
            }
            Dealer.Hidden = Dealer.Deal();

            return State;
        }

        public override Dictionary<string, object> Step(string action)
        {
            // Prevent the user from passing invalid action and check for game over
            if (IsOver()) return State;
            if (!GetLegalActions().Contains(action)) throw new Exception("Invalid action!");

            // Handle player action
            switch (action)
            {
                case "hit":
                    HitAction();
                    break;
                case "stand":
                    StandAction();
                    break;
            }

            // Handle dealer action at the end of the round
            if (CurrentPlayer == Players.Count() - 1 && Players[CurrentPlayer].Status == PlayerStatus.Dead)
            {
                Dealer.Visible.Add(Dealer.Hidden);
                while (Judge.JudgeDealer(Dealer) < 17)
                {
                    Dealer.Visible.Add(Dealer.Deal());
                }
            }
            else
            {
                CurrentPlayer++;
            }

            return State;
        }

        private void HitAction()
        {
            Players[CurrentPlayer].Cards.Add(Dealer.Deal());
            if (Judge.JudgePlayer(Players[CurrentPlayer]) >= 21)
            {
                Players[CurrentPlayer].Status = PlayerStatus.Dead;
            }
        }

        private void StandAction()
        {
            Players[CurrentPlayer].Status = PlayerStatus.Dead;
        }
    }
}
