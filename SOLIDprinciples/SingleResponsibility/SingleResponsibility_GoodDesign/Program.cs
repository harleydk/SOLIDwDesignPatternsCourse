using SingleResponsibility;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private static async Task Main()
        {
            Player player = new();

            GameHitPointManager gameHitPointManager = new(player);
            gameHitPointManager.UpdateHitPoints(HitType.CriticalHit);

            LeaderboardService leaderboardService = new LeaderboardService();
            await leaderboardService.UpdateScore(player);
            if (leaderboardService.IsHighScore(player))
            {
                SaveGameService saveGameService = new(new List<Player> { player });
                await saveGameService.Save();
            }
        }
    }
}