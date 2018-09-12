using System;

namespace TennisGame
{
    public class GameScoreManager : IGameScoreManager
    {
        private Player _playerA = null;
        private Player _playerB = null;

        public GameScoreManager(Player playerA, Player playerB)
        {
            _playerA = playerA;
            _playerB = playerB;
        }

        public void UpdateScore(Players winningPointPlayer)
        {
            if (winningPointPlayer == Players.PlayerA)
            {
                // Player A made the point
                if (_playerB.Score == Points.Advantage)
                {
                    _playerB.Score = Points.Forty;
                }
                else
                {
                    _playerA.Score = (Points)((int)_playerA.Score + 1);

                }
            }
            else
            {
                // Player B made the point
                if (_playerA.Score == Points.Advantage)
                {
                    _playerA.Score = Points.Forty;
                }
                else
                {
                    _playerB.Score = (Points)((int)_playerB.Score + 1);
                }
            }
        }

        public Players CheckGameWinner(Players winningPointPlayer)
        {
            Players winner = Players.None;
            if (winningPointPlayer == Players.PlayerA)
            {
                // Player A made the point
                if (_playerA.Score == Points.Advantage ||
                    (_playerA.Score == Points.Forty &&
                    _playerB.Score != Points.Forty &&
                    _playerB.Score != Points.Advantage))
                {
                    winner = Players.PlayerA;
                }
            }
            else
            {
                // Player B made the point
                if (_playerB.Score == Points.Advantage ||
                    (_playerB.Score == Points.Forty &&
                    _playerA.Score != Points.Forty &&
                    _playerA.Score != Points.Advantage))
                {
                    winner = Players.PlayerB;
                }
            }
            return winner;
        }



    }
}