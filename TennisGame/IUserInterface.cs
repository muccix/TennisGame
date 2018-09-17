namespace TennisGame
{
    public interface IUserInterface
    {
        void PrintWelcome(string message);

        void PrintMessage(string message);

        void PrintScore(string score);

        void ClearPage();

        void WaitUserAction();
    }
}