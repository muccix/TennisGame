using System;

namespace TennisGame
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void WaitUserAction()
        {
            Console.ReadKey(true);
        }
    }
}