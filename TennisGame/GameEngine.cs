using System;

namespace TennisGame
{
    public class GameEngine
    {
        private readonly IPointResultEngine _pointResultEngine;
        private readonly IGameScoreManager _gameScoreManager;

        private readonly IUserInterface _userInterface;
        private readonly Player _playerA;
        private readonly Player _playerB;

        public GameEngine(IPointResultEngine pointResultEngine,
                            IGameScoreManager gameScoreManager,
                            IUserInterface userInterface,
                            Player playerA,
                            Player playerB)
        {
            if (pointResultEngine == null)
                throw new ArgumentNullException("pointResultEngine");

            if (gameScoreManager == null)
                throw new ArgumentNullException("gameScoreManager");

            if (playerA == null)
                throw new ArgumentNullException("playerA");

            if (playerB == null)
                throw new ArgumentNullException("playerB");

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

            _userInterface.ShowStrongMessage(message);
            while (true)
            {
                PrintCurrentScore();

                _userInterface.ShowMessage("Press any key to play the point...");
                _userInterface.WaitUserAction();
                _userInterface.ClearPage();

                string pointWinnerPlayerName = _pointResultEngine.GetPointWinnerPlayerName(_playerA, _playerB);
                _userInterface.ShowMessage($"\n{pointWinnerPlayerName} won the point.");

                _gameScoreManager.UpdateScore(_playerA, _playerB, pointWinnerPlayerName);
                gameWinnerName = _gameScoreManager.GetGameWinnerName(_playerA, _playerB);
                if (gameWinnerName != "")
                    break;
            }

            _userInterface.ShowMessage($"{gameWinnerName} WINS THE GAME!!\n");
            return gameWinnerName;
        }

        private void PrintCurrentScore()
        {
            if (_playerA.Score == Points.Forty && _playerB.Score == Points.Forty)
            {
                _userInterface.ShowMessage("DEUCE!");
            }
            else if (_playerA.Score == Points.Advantage)
            {
                _userInterface.ShowMessage($"ADVANTAGE {_playerA.Name}!");
            }
            else if (_playerB.Score == Points.Advantage)
            {
                _userInterface.ShowMessage($"ADVANTAGE {_playerB.Name}!");
            }

            string scoreMessage = $"{_playerA.Name} - {_playerA.Score}\n{_playerB.Name} - {_playerB.Score}";
            _userInterface.ShowScore(_playerA.Name, _playerA.Score, _playerB.Name, _playerB.Score);
        }
    }
}