using SingleResponsibility;
using System.Threading.Tasks;

namespace SingleResponsibility_BadDesign
{
    /// <summary>
    /// The <see cref="GameHitPointManager"/> manages the calculation of a player's hit points.
    /// </summary>
    public sealed class GameHitPointManager(Player player, SaveGameService saveGameService, LeaderboardService leaderboardService)
    {
        /// <summary>
        /// This method really has too much responsibility on its hands. For a number of reasons we might need to change it:
        /// - to add further hit-types,
        /// - or modify the logic regarding updating of scores and high-scores,
        /// - and the save-logic should not be the responsibility of a class that calculates hit points.
        /// </summary>
        public async Task<GameHitPointManagerOperationStatus> UpdateHitPoints(HitType hitType)
        {
            player.HitPoints += hitType switch
            {
                HitType.NoHit => 0,
                HitType.Hit => 1,
                HitType.CriticalHit => 5,
                _ => 0 // for all other types of hit, add 0.
            };

            await leaderboardService.UpdateScore(player);
            if (leaderboardService.IsHighScore(player))
            {
                await saveGameService.Save();
            }

            return await Task.FromResult(GameHitPointManagerOperationStatus.PresumedSucceeded);
        }
    }

    public enum GameHitPointManagerOperationStatus
    {
        Succeeded,
        Failed,
        PresumedSucceeded
    }
}