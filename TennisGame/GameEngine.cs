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
            _pointResultEngine = pointResultEngine;
            _gameScoreManager = gameScoreManager;
            _userInterface = userInterface;
            _playerA = playerA;
            _playerB = playerB;
        }

        public void PlayGame()
        {
            Players gameWinner = Players.None;
            if (_pointResultEngine == null)
                throw new ArgumentNullException("PointResultEngine is missing");

            if (_gameScoreManager == null)
                throw new ArgumentNullException("GameScoreManager is missing");

            _userInterface.Clear();
            string message = $@"
*****************************
WELCOME TO THE TENNIS GAME!
{_playerA.Name} vs {_playerB.Name}: who is going to win this game?
*****************************";

            _userInterface.SendMessage(message);
            PrintCurrentScore();
            while (true)
            {
                _userInterface.SendMessage("Press any key to play the point...");
                _userInterface.WaitUserAction();
                _userInterface.Clear();

                var player = _pointResultEngine.GetPointWinnerPlayer();
                var pointWinnerName = player == Players.PlayerA ? _playerA.Name : _playerB.Name;
                _userInterface.SendMessage($"\n{pointWinnerName} won the point.");

                gameWinner = _gameScoreManager.CheckGameWinner(player);
                if (gameWinner != Players.None)
                    break;

                _gameScoreManager.UpdateScore(player);
                PrintCurrentScore();
            }

            var gameWinnerName = gameWinner == Players.PlayerA ? _playerA.Name : _playerB.Name;
            _userInterface.SendMessage($"{gameWinnerName} WINS THE GAME!!\n");
        }

        private void PrintCurrentScore()
        {
            if (_playerA.Score == Points.Forty && _playerB.Score == Points.Forty)
            {
                _userInterface.SendMessage("DEUCE!");
            }
            else if (_playerA.Score == Points.Advantage)
            {
                _userInterface.SendMessage($"ADVANTAGE {_playerA.Name}!");
            }
            else if (_playerB.Score == Points.Advantage)
            {
                _userInterface.SendMessage($"ADVANTAGE {_playerB.Name}!");
            }

            string message = $@"
-----------------
{_playerA.Name} - {_playerA.Score}
{_playerB.Name} - {_playerB.Score}
-----------------";
            _userInterface.SendMessage(message);
        }
    }
}