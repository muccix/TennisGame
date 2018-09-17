using System;

namespace TennisGame
{
    public class RandomPointResultEngine : IPointResultEngine
    {
        public string GetPointWinnerPlayerName(Player playerA, Player playerB)
        {
            var random = new Random();
            return random.Next(0, 2) == 0 ? playerA.Name : playerB.Name;
        }
    }
}