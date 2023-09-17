using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class SaveGameService
    {
        private readonly List<Player> _players;

        public SaveGameService(List<Player> players)
        {
            _players = players;
        }

        public async Task Save()
        {
            try
            {
                _players.ForEach(player =>
                {
                    System.Diagnostics.Debug.WriteLine($"Saving {player.Name}...");
                });

                await Task.CompletedTask;
            }
            catch (Exception)
            {
                throw new SaveGameException();
            }

        }
    }

    [System.Serializable]
    public class SaveGameException : System.Exception
    {
        public SaveGameException() { }
        public SaveGameException(string message) : base(message) { }
        public SaveGameException(string message, System.Exception inner) : base(message, inner) { }
        protected SaveGameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}