using System;

namespace TennisGame
{
    public interface IUserInterface
    {
        void SendMessage(string message);

        void Clear();

        void WaitUserAction();

    }
}