using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task UpdateScore(Player player)
        {
            try
            {
                if (player.HitPoints > 100)
                {
                    System.Diagnostics.Debug.WriteLine($"{player.Name}: {player.HitPoints}");
                    await Task.CompletedTask;
                }
            }
            catch (Exception)
            {
                throw new LeaderBoardServiceException();
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


    [Serializable]
    public class LeaderBoardServiceException : Exception
    {
        public LeaderBoardServiceException() { }
        public LeaderBoardServiceException(string message) : base(message) { }
        public LeaderBoardServiceException(string message, Exception inner) : base(message, inner) { }
        protected LeaderBoardServiceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}