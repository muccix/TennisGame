using System;

namespace TennisGame
{
    public interface IGameScoreManager
    {
        void UpdateScore(Player playerA,
                         Player playerB,
                         string winningPointPlayer);

        string GetGameWinnerName(Player playerA, Player playerB);
    }
}