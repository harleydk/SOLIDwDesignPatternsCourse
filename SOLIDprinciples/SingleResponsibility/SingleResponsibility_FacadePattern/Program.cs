using SingleResponsibility;
using System.Collections.Generic;

namespace SingleResponsibility_FaçadePattern
{
    public sealed class Program
    {
        /// <summary>
        /// What if we can't separate the diverse responsibilities - if we absolutely <b>must</b> present a single common class, 
        /// perhaps in order to fulfill a previously arranged contract?:
        /// We can use the Façade-pattern to enable separation of concerns, yet still combine them to present a common front.
        /// </summary>
        private static void Main()
        {
            Player player = new();
            SaveGameService saveGameService = new(new List<Player> { player });
            LeaderboardService leaderboardService = new LeaderboardService();

            GameHitPointManagerFaçade gameHitPointManagerFaçade = new(player, saveGameService, leaderboardService); // Probably a good idea to name it '<something>Façade'
            gameHitPointManagerFaçade.UpdateHitPoints(HitType.CriticalHit);
            gameHitPointManagerFaçade.UpdateLeaderBoardServiceScore();
            gameHitPointManagerFaçade.SaveIfPlayerGotHighScore();

        }
    }
}