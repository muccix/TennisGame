using System;

namespace TennisGame
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void PrintMessage(string message)
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

        public void PrintWelcome(string message)
        {
            Console.WriteLine(
            $@"
*****************************
{message}
*****************************");
        }

        public void PrintScore(string score)
        {
            Console.WriteLine(
                $@"
-----------------
{score}
-----------------");
        }
    }
}