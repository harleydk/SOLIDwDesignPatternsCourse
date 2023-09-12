using SingleResponsibility;

namespace SingleResponsibility_BadDesign
{
    /// <summary>
    /// The <see cref="GameHitPointManager"/> manages the calculation of a player's hit points.
    /// </summary>
    public sealed class GameHitPointManager
    {
        private readonly Player _player;
        private readonly SaveGameService _saveGameService;
        private readonly LeaderboardService _leaderboardService;

        public GameHitPointManager(Player player, SaveGameService saveGameService, LeaderboardService leaderboardService)
        {
            _player = player;
            _saveGameService = saveGameService;
            _leaderboardService = leaderboardService;
        }

        /// <summary>
        /// This method really has too much responsibility on its hands. For a number of reasons we might need to change it:
        /// - to add further hit-types,
        /// - or modify the logic regarding updating of scores and high-scores,
        /// - and the save-logic should not be the responsibility of a class that calculates hit points.
        /// </summary>
        public void UpdateHitPoints(HitType hitType)
        {
            _player.HitPoints += hitType switch
            {
                HitType.NoHit => 0,
                HitType.Hit => 1,
                HitType.CriticalHit => 5,
                _ => 0 // for all other types of hit, add 0.
            };

            _leaderboardService.UpdateScore(_player);
            if (_leaderboardService.IsHighScore(_player))
            {
                _saveGameService.Save();
            }
        }
    }
}