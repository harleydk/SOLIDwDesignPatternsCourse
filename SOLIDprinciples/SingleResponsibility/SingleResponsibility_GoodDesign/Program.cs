using SingleResponsibility;
using System.Collections.Generic;

namespace SingleResponsibility_GoodDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The better we separate the concerns, the <i>usually</i> the better. 
        /// 
        /// Beyond the 'regular' benefits of honoring the single responsibility principle (i.e. reduced coupling, better maintainability,
        /// easier testability, less risk of technical debt, etc.), note now, in the below, the 
        /// separation of concerns allows us to defer the creation of the services. That's certainly a positive side-effect.
        /// </summary>
        private static void Main()
        {
            Player player = new();

            GameHitPointManager gameHitPointManager = new(player);
            gameHitPointManager.UpdateHitPoints(HitType.CriticalHit);

            LeaderboardService leaderboardService = new LeaderboardService();
            leaderboardService.UpdateScore(player);
            if (leaderboardService.IsHighScore(player))
            {
                SaveGameService saveGameService = new(new List<Player> { player });
                saveGameService.Save();
            }
        }
    }
}