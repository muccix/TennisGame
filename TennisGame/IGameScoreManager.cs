using System;

namespace TennisGame
{
    public interface IGameScoreManager
    {
        void UpdateScore(Player playerA,
                         Player playerB,
                         Players winningPointPlayer);

        Players CheckGameWinner(Player playerA, Player playerB);
    }
}