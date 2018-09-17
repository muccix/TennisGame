using System;

namespace TennisGame
{
    public interface IPointResultEngine
    {
        string GetPointWinnerPlayerName(string playerAName, string playerBName);
    }
}