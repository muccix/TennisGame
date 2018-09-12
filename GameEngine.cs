using System;

namespace TennisGame
{
    public class GameEngine
    {
        private readonly IPointResultEngine _pointResultEngine;
        private readonly IGameScoreManager _gameScoreManager;
        private Player _playerA = null;
        private Player _playerB = null;

        public GameEngine(IPointResultEngine pointResultEngine,
                            IGameScoreManager gameScoreManager,
                            Player playerA,
                            Player playerB)
        {
            _pointResultEngine = pointResultEngine;
            _gameScoreManager = gameScoreManager;
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

            while (true)
            {
                // System.Console.ReadLine("Press any key to play the point...");
                var player = _pointResultEngine.GetPointWinnerPlayer();
                var pointWinnerName = player == Players.PlayerA ? _playerA.Name : _playerB.Name;
                System.Console.WriteLine($"{pointWinnerName} won the point.\n");
                gameWinner = _gameScoreManager.CheckGameWinner(player);
                if (gameWinner != Players.None)
                    break;

                _gameScoreManager.UpdateScore(player);
                PrintCurrentScore();
            }

            var gameWinnerName = gameWinner == Players.PlayerA ? _playerA.Name : _playerB.Name;
            System.Console.WriteLine($"Game ended. {gameWinner} win the game!");

        }



        private void PrintCurrentScore()
        {
            System.Console.WriteLine($"{_playerA.Name} - {_playerA.Score}");
            System.Console.WriteLine($"{_playerB.Name} - {_playerB.Score}\n");
        }
    }
}