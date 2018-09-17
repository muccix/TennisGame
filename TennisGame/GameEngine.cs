using System;

namespace TennisGame
{
    public class GameEngine
    {
        private readonly IPointResultEngine _pointResultEngine;
        private readonly IGameScoreManager _gameScoreManager;

        private readonly IUserInterface _userInterface;
        private Player _playerA = null;
        private Player _playerB = null;

        public GameEngine(IPointResultEngine pointResultEngine,
                            IGameScoreManager gameScoreManager,
                            IUserInterface userInterface,
                            Player playerA,
                            Player playerB)
        {
            if (pointResultEngine == null)
                throw new ArgumentNullException("PointResultEngine");

            if (gameScoreManager == null)
                throw new ArgumentNullException("GameScoreManager");

            if (playerA == null)
                throw new ArgumentNullException("PlayerA");

            if (playerB == null)
                throw new ArgumentNullException("PlayerB");

            if (playerA.Name == playerB.Name)
                throw new ArgumentException("Players can't have the same name");

            _pointResultEngine = pointResultEngine;
            _gameScoreManager = gameScoreManager;
            _userInterface = userInterface;
            _playerA = playerA;
            _playerB = playerB;
        }

        public string PlayGame()
        {
            string gameWinnerName = "";

            _userInterface.ClearPage();
            string message = $"WELCOME TO THE TENNIS GAME!\n{_playerA.Name} vs {_playerB.Name}: who is going to win this game?";

            _userInterface.PrintWelcome(message);
            while (true)
            {
                PrintCurrentScore();

                _userInterface.PrintMessage("Press any key to play the point...");
                _userInterface.WaitUserAction();
                _userInterface.ClearPage();

                string pointWinnerPlayerName = _pointResultEngine.GetPointWinnerPlayerName(_playerA.Name, _playerB.Name);
                _userInterface.PrintMessage($"\n{pointWinnerPlayerName} won the point.");

                _gameScoreManager.UpdateScore(_playerA, _playerB, pointWinnerPlayerName);
                gameWinnerName = _gameScoreManager.GetGameWinnerName(_playerA, _playerB);
                if (gameWinnerName != "")
                    break;
            }

            _userInterface.PrintMessage($"{gameWinnerName} WINS THE GAME!!\n");
            return gameWinnerName;
        }

        private void PrintCurrentScore()
        {
            if (_playerA.Score == Points.Forty && _playerB.Score == Points.Forty)
            {
                _userInterface.PrintMessage("DEUCE!");
            }
            else if (_playerA.Score == Points.Advantage)
            {
                _userInterface.PrintMessage($"ADVANTAGE {_playerA.Name}!");
            }
            else if (_playerB.Score == Points.Advantage)
            {
                _userInterface.PrintMessage($"ADVANTAGE {_playerB.Name}!");
            }

            string scoreMessage = $"{_playerA.Name} - {_playerA.Score}\n{_playerB.Name} - {_playerB.Score}";
            _userInterface.PrintScore(scoreMessage);
        }
    }
}