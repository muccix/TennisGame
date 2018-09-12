using System;

namespace TennisGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerA = new Player(Players.PlayerA, "Roger");
            var playerB = new Player(Players.PlayerB, "Rafa");
            var randomPointResultEngine = new RandomPointResultEngine();
            var gameScoreManager = new GameScoreManager(playerA, playerB);

            var gameEngine = new GameEngine(randomPointResultEngine,
                                            gameScoreManager,
                                            playerA,
                                            playerB);

            Console.WriteLine("Welcome to the Tennis Game!");
            System.Console.WriteLine("Roger vs Rafa: who is going to win this game?");

            gameEngine.PlayGame();

        }
    }
}
