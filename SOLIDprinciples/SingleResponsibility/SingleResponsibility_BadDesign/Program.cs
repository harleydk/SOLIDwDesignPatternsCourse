using SingleResponsibility;
using System.Collections.Generic;

namespace SingleResponsibility_BadDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The Single Responsibility principle states that a class should have only one reason to change. In the below, the <see cref="GameHitPointManager"/> has many 
        /// responsibilities, namely calculating hit points, comparing the score against a leaderboard, and saving game data. This <i>per se</i> does not break with the single 
        /// responsibility; that will only occur if and when we ultimately have to change any aspect about the class, and for all we know
        /// years might pass and we'd never actually get to change it. 
        /// <b>However. A reasonable case can be made how the multiple responsibilities of the class renders it vulnerable to change</b> - so let's 
        /// set about bettering it.
        /// </summary>
        /// <remarks>
        /// Related to the notion of single responsibility are the concepts of Cohesion vs coupling.
        /// TOOD: describe the two, and the differences between them. 
        /// </remarks>
        private static void Main()
        {
            Player player = new();
            SaveGameService saveGameService = new(new List<Player> { player });
            LeaderboardService leaderboardService = new();

            GameHitPointManager gameHitPointManager = new(player, saveGameService, leaderboardService);
            _ = gameHitPointManager.UpdateHitPoints(HitType.CriticalHit);
        }
    }
}