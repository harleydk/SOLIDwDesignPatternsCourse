using System.Collections.Generic;

namespace SingleResponsibility
{
    public class SaveGameService
    {
        private readonly List<Player> _players;

        public SaveGameService(List<Player> players)
        {
            _players = players;
        }

        public void Save()
        {
            _players.ForEach(player =>
            {
                System.Diagnostics.Debug.WriteLine($"Saving {player.Name}...");
            });
        }
    }
}