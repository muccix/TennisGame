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
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                            gameScoreManager,
                                            consoleUserInterface,
                                            playerA,
                                            playerB);
            gameEngine.PlayGame();
        }
    }
}
