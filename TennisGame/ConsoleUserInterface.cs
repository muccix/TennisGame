using System;

namespace TennisGame
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ClearPage()
        {
            Console.Clear();
        }

        public void WaitUserAction()
        {
            Console.ReadKey(true);
        }

        public void ShowStrongMessage(string message)
        {
            Console.WriteLine(
            $@"
*****************************
{message}
*****************************");
        }

        public void ShowScore(string playerAName,
                               Points playerAScore,
                               string playerBName,
                               Points playerBScore)
        {
            Console.WriteLine(
                $@"
-----------------
{playerAName} - {playerAScore}
{playerBName} - {playerBScore}
-----------------");
        }
    }
}