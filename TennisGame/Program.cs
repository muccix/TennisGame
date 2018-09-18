namespace TennisGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var playerA = new Player("");
                var playerB = new Player("ROGER");
                var randomPointResultEngine = new RandomPointResultEngine();
                var gameScoreManager = new GameScoreManager();
                var consoleUserInterface = new ConsoleUserInterface();

                var gameEngine = new GameEngine(randomPointResultEngine,
                                                gameScoreManager,
                                                consoleUserInterface,
                                                playerA,
                                                playerB);
                gameEngine.PlayGame();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
            }

        }
    }
}
