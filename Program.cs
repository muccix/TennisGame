using System;

namespace TennisGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerA = new Player(Players.PlayerA, "ROGER");
            var playerB = new Player(Players.PlayerB, "RAFA");
            var randomPointResultEngine = new RandomPointResultEngine();
            var gameScoreManager = new GameScoreManager(playerA, playerB);

            var gameEngine = new GameEngine(randomPointResultEngine,
                                            gameScoreManager,
                                            playerA,
                                            playerB);
            Console.Clear();
            System.Console.WriteLine("\n*****************************");
            Console.WriteLine("Welcome to the Tennis Game!");
            System.Console.WriteLine($"{playerA.Name} vs {playerB.Name}: who is going to win this game?");
            System.Console.WriteLine("*****************************\n");

            gameEngine.PlayGame();
        }
    }
}
