using SingleResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleResponsibility
{
    /// <summary>
    /// The <see cref="LeaderboardService"/> writes a players' game-score to the leaderboard.
    /// </summary>
    public class LeaderboardService
    {
        private readonly List<Player> _players;

        public LeaderboardService()
        {
            _players = new List<Player>();
        }

        public void UpdateScore(Player player)
        {
            if (player.HitPoints > 100)
            {
                System.Diagnostics.Debug.WriteLine($"{player.Name}: {player.HitPoints}");
            }
        }

        public bool IsHighScore(Player player)
        {
            bool isNewPlayer = _players.Any(p => p.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase));
            if (isNewPlayer)
            {
                _players.Add(player);
                return false;
            }
            else
            {
                Player existingPlayer = _players.SingleOrDefault(p => p.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException("Unknown player!");
                if (player.HitPoints > existingPlayer.HitPoints)
                {
                    existingPlayer.HitPoints = player.HitPoints;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}