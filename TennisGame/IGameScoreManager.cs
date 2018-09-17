using System;

namespace TennisGame
{
    public interface IGameScoreManager
    {
        void UpdateScore(Player playerA,
                         Player playerB,
                         string winningPointPlayerName);

        string GetGameWinnerName(Player playerA, Player playerB);
    }
}