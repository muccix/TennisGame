namespace TennisGame
{
    public interface IUserInterface
    {
        void PrintWelcome(string message);

        void PrintMessage(string message);

        void PrintScore(string playerAName,
                        Points playerAScore,
                        string playerBName,
                        Points playerBScore);

        void ClearPage();

        void WaitUserAction();
    }
}