using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Games.Blackjack
{
    internal static class Judge
    {
        public static List<(int PlayerId, int Payoff)> JudgeGame(Game game)
        {
            List<(int PlayerId, int Payoff)> payoffs = new List<(int PlayerId, int Payoff)> ();
            int dealerScore = JudgeDealer(game.Dealer);

            foreach (Player player in game.Players)
            {
                int score = JudgePlayer(player);
                if (score == 21 && dealerScore != 21) payoffs.Add((PlayerId: player.Id, Payoff: 1));
                else if (score > 21) payoffs.Add((PlayerId: player.Id, Payoff: -1));
                else if (dealerScore > 21) payoffs.Add((PlayerId: player.Id, Payoff: 1));
                else if (score > dealerScore) payoffs.Add((PlayerId: player.Id, Payoff: 1));
                else if (score == dealerScore) payoffs.Add((PlayerId: player.Id, Payoff: 0));
                else payoffs.Add((PlayerId: player.Id, Payoff: -1));
            }

            return payoffs;
        }

        public static int JudgeDealer(Dealer dealer)
        {
            int score = 0;
            int aceCount = 0;

            foreach (string card in dealer.Visible)
            {
                if (card[1] == 'A') aceCount++;
                score += GetCardScore(card);
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (score > 21) score -= 10;
            }

            return score;
        }

        public static int JudgePlayer(Player player)
        {
            int score = 0;
            int aceCount = 0;

            foreach (string card in player.Cards)
            {
                if (card[1] == 'A') aceCount++;
                score += GetCardScore(card);
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (score > 21) score -= 10;
            }

            return score;
        }

        private static int GetCardScore(string card)
        {
            Dictionary<string, int> score = new Dictionary<string, int>
            { 
                ["J"] =  10,
                ["Q"] =  10,
                ["K"] =  10,
                ["A"] =  11,
            };

            string cardNumber = card.Substring(1);

            if (Int32.TryParse(cardNumber, out int cardValue)) return cardValue;
            else if (score.ContainsKey(cardNumber)) return score[cardNumber];

            return 0;
        }
    }
}
