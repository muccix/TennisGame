using System;

namespace TennisGame
{
    public class Player
    {
        public string Name { get; private set; }

        public Points Score { get; set; }

        public Player(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Players name can not be empty, null or white spaces only");
            Name = name;
        }

    }
}