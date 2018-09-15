using System;

namespace TennisGame
{
    public class Player
    {
        public Players Id  { get; set; }

        public string Name { get; set; }

        public Points Score { get; set; }

        public Player(string name)
        {
            Id = PlayerIdManager.GetPlayerId();
            Name = name;
        }

    }
}