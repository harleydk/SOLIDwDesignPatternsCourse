﻿using SingleResponsibility;

namespace SingleResponsibility_GoodDesign
{
    /// <summary>
    /// The <see cref="GameHitPointManager"/> manages the calculation of a player's hit points.
    /// </summary>
    public sealed class GameHitPointManager
    {
        private readonly Player _player;

        public GameHitPointManager(Player player)
        {
            _player = player;
        }

        public GameHitPointManagerOperationStatus UpdateHitPoints(HitType hitType)
        {
            _player.HitPoints += hitType switch
            {
                HitType.NoHit => 0,
                HitType.Hit => 1,
                HitType.CriticalHit => 5,
                _ => 0 // for all other types of hit, add 0.
            };

            return GameHitPointManagerOperationStatus.PresumedSucceeded;
        }
    }

    public enum GameHitPointManagerOperationStatus
    {
        Succeeded,
        Failed,
        PresumedSucceeded
    }
}