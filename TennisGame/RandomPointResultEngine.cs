using System;

namespace TennisGame
{
    public class RandomPointResultEngine : IPointResultEngine
    {
        public Players GetPointWinnerPlayer()
        {
            var random = new Random();
            var player = random.Next(0, 2) == 0 ? Players.A : Players.B;
            return player;
        }
    }
}