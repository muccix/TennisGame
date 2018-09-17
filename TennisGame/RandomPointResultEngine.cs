using System;

namespace TennisGame
{
    public class RandomPointResultEngine : IPointResultEngine
    {
        public string GetPointWinnerPlayerName(string playerAName, string playerBName)
        {
            var random = new Random();
            return random.Next(0, 2) == 0 ? playerAName : playerBName;
        }
    }
}