using System;

namespace TennisGame
{
    public class GameScoreManager : IGameScoreManager
    {
        public void UpdateScore(Player playerA,
                                Player playerB,
                                string winningPointPlayerName)
        {
            if (winningPointPlayerName == playerA.Name)
            {
                if (playerA.Score >= Points.Forty && 
                    (int)playerA.Score - (int)playerB.Score >= 1)
                {
                    playerA.Score = Points.Game;
                    return;
                }

                if (playerB.Score == Points.Advantage)
                {
                    playerB.Score = Points.Forty;
                }
                else
                {
                    playerA.Score = (Points)((int)playerA.Score + 1);
                }
            }
            else
            {
                if (playerB.Score >= Points.Forty &&
                    (int)playerB.Score - (int)playerA.Score >= 1)
                {
                    playerB.Score = Points.Game;
                    return;
                }

                if (playerA.Score == Points.Advantage)
                {
                    playerA.Score = Points.Forty;
                }
                else
                {
                    playerB.Score = (Points)((int)playerB.Score + 1);
                }
            }
        }

        public string GetGameWinnerName(Player playerA, Player playerB)
        {
            string winner = "";
            if (playerA.Score == Points.Game)
            {
                winner = playerA.Name;
            }
            else if (playerB.Score == Points.Game)
            {
                winner = playerB.Name;
            }

            return winner;
        }
    }
}