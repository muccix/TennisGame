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
                if (isWinnerPlayerA())
                {
                    winner = Players.PlayerA;
                }
            }
            else
            {
                if (isWinnerPlayerB())
                {
                    winner = Players.PlayerB;
                }
            }

            return winner;
        }

        private bool isWinnerPlayerA()
        {
            bool result = false;
            if (_playerA.Score == Points.Advantage ||
                (_playerA.Score == Points.Forty && (int)_playerB.Score < (int)Points.Forty))
            {
                result = true;
            }

            return result;
        }

        private bool isWinnerPlayerB()
        {
            bool result = false;
            if (_playerB.Score == Points.Advantage ||
                (_playerB.Score == Points.Forty && (int)_playerA.Score < (int)Points.Forty))
            {
                result = true;
            }

            return result;
        }
    }
}