using System;

namespace TennisGame
{
    public class Player
    {
        public Players Id { get; set; }

        public string Name { get; set; }

        public Points Score { get; set; }


        public Player(Players id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}