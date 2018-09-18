namespace TennisGame
{
    public interface IUserInterface
    {
        void ShowStrongMessage(string message);

        void ShowMessage(string message);

        void ShowScore(string playerAName,
                        Points playerAScore,
                        string playerBName,
                        Points playerBScore);

        void ClearPage();

        void WaitUserAction();
    }
}