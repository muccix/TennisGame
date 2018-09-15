using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public static class PlayerIdManager
    {
        private static int playerId;
        public static Players GetPlayerId()
        {
            // Only 2 players allowed
            if (playerId > 1)
            {
                playerId = 0;
            }

            playerId++;
            return (Players)(playerId);
        }
    }
}
