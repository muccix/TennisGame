using System;

namespace TennisGame
{
    public class Player
    {
        public string Name { get; private set; }

        public Points Score { get; set; }

        public Player(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Players name can not be empty or null");
            Name = name;
        }

    }
}