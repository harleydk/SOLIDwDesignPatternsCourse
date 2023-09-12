using SingleResponsibility;

namespace SingleResponsibility_FaçadePattern
{
    /// <summary>
    /// The <see cref="GameHitPointManagerFaçade"/> manages the calculation of a player's hit points, 
    /// as well as comparing against a <see cref="LeaderboardService"/> and saving game state via a <seealso cref="SaveGameService"/>
    /// </summary>
    public sealed class GameHitPointManagerFaçade
    {
        private readonly Player _player;
        private readonly SaveGameService _saveGameService;
        private readonly LeaderboardService _leaderboardService;

        public GameHitPointManagerFaçade(Player player, SaveGameService saveGameService, LeaderboardService leaderboardService)
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
        }

        public void UpdateLeaderBoardServiceScore()
        {
            _leaderboardService.UpdateScore(_player);
        }

        public void SaveIfPlayerGotHighScore()
        {
            if (_leaderboardService.IsHighScore(_player))
            {
                _saveGameService.Save();
            }
        }
    }
}