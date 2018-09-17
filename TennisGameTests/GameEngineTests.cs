using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Players can't have the same name")]
        public void GameEngine_PlayersWithSameName_ThrowException()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("ROGER");
            RandomPointResultEngine randomPointResultEngine = null;
            var gameScoreManager = new GameScoreManager();
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "PointResultEngine")]
        public void GameEngine_PointResultEngineIsNull_ThrowException()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("RAFA");
            RandomPointResultEngine randomPointResultEngine = null;
            var gameScoreManager = new GameScoreManager();
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "GameScoreManager")]
        public void GameEngine_GameScoreManagerIsNull_ThrowException()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("RAFA");
            var randomPointResultEngine = new RandomPointResultEngine();
            GameScoreManager gameScoreManager = null;
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "PlayerA")]
        public void GameEngine_PlayerAIsNull_ThrowException()
        {
            Player playerA = null;
            var playerB = new Player("RAFA");
            var randomPointResultEngine = new RandomPointResultEngine();
            var gameScoreManager = new GameScoreManager();
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "PlayerB")]
        public void GameEngine_PlayerBIsNull_ThrowException()
        {
            var playerA = new Player("ROGER");
            Player playerB = null;
            var randomPointResultEngine = new RandomPointResultEngine();
            var gameScoreManager = new GameScoreManager();
            var consoleUserInterface = new ConsoleUserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);
        }

        [TestMethod]
        public void PlayGame_PlayerAAlwaysWinThePoint_PlayerAWinsTheGame()
        {
            var playerA = new Player("ROGER");
            var playerB = new Player("RAFA");
            var randomPointResultEngine = new Fake_PlayerAAlwaysWinResultEngine();
            var gameScoreManager = new GameScoreManager();
            var consoleUserInterface = new Fake_UserInterface();

            var gameEngine = new GameEngine(randomPointResultEngine,
                                gameScoreManager,
                                consoleUserInterface,
                                playerA,
                                playerB);

            var winner = gameEngine.PlayGame();
            Assert.AreEqual(playerA.Name, winner);
        }

    [TestMethod]
    public void PlayGame_PlayerBAlwaysWinThePoint_PlayerBWinsTheGame()
    {
        var playerA = new Player("ROGER");
        var playerB = new Player("RAFA");
        var randomPointResultEngine = new Fake_PlayerBAlwaysWinResultEngine();
        var gameScoreManager = new GameScoreManager();
        var consoleUserInterface = new Fake_UserInterface();

        var gameEngine = new GameEngine(randomPointResultEngine,
                            gameScoreManager,
                            consoleUserInterface,
                            playerA,
                            playerB);

        var winner = gameEngine.PlayGame();
        Assert.AreEqual(playerB.Name, winner);
    }
}

public class Fake_PlayerAAlwaysWinResultEngine : IPointResultEngine
    {
        public string GetPointWinnerPlayerName(Player playerA, Player playerB)
        {
            return playerA.Name;
        }
    }

    public class Fake_PlayerBAlwaysWinResultEngine : IPointResultEngine
    {
        public string GetPointWinnerPlayerName(Player playerA, Player playerB)
        {
            return playerB.Name;
        }
    }

    public class Fake_UserInterface : IUserInterface
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            return;
        }

        public void WaitUserAction()
        {
            return;
        }

        public void PrintWelcome(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintScore(string playerAName,
                               Points playerAScore,
                               string playerBName,
                               Points playerBScore)
        {
            Console.WriteLine(
                $@"
-----------------
{playerAName} - {playerAScore}
{playerBName} - {playerBScore}
-----------------");
        }

        public void ClearPage()
        {
            return;
        }
    }
}