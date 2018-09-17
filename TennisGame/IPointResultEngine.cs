using System;

namespace TennisGame
{
    public interface IPointResultEngine
    {
        string GetPointWinnerPlayerName(Player playerA, Player playerB);
    }
}