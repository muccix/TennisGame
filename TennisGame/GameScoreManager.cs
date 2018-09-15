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
            if (winningPointPlayer == Players.A)
            {
                if (_playerA.Score >= Points.Forty && 
                    (int)_playerA.Score - (int)_playerB.Score >= 1)
                {
                    _playerA.Score = Points.Game;
                    return;
                }

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
                if (_playerB.Score >= Points.Forty &&
                    (int)_playerB.Score - (int)_playerA.Score >= 1)
                {
                    _playerB.Score = Points.Game;
                    return;
                }

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

        public Players CheckGameWinner()
        {
            Players winner = Players.None;
            if (_playerA.Score == Points.Game)
            {
                winner = Players.A;
            }
            else if (_playerB.Score == Points.Game)
            {
                winner = Players.B;
            }

            return winner;
        }
    }
}