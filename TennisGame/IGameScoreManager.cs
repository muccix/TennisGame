using System;

namespace TennisGame
{
    public interface IGameScoreManager
    {
        void UpdateScore(Players winningPointPlayer);

        Players CheckGameWinner();
    }
}