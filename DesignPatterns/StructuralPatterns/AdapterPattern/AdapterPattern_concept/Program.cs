using System;

namespace DesignPatterns.Adapter.Structural
{
    public sealed class Program
    {
        /// <summary>
        /// The Adapter Pattern is for when we need to force a class to adhere to a specific interface. This we do by creating an adapter-class which wraps the adaptee-subject, and returns relegation to the adaptee's methods while implementing the target interface.
        /// </summary>
        /// <example>
        /// Real life uses includes
        ///     - wrapping third party components.
        ///     - blocking off deprecated methods that no longer needs to be used.
        ///     - hot-fixing erroneous components - fx changing pins on a socket, if we're suddenly delivered the wrong one.
        ///     - for legacy code maintenance work - fx adapting a DAL to use a new database-driver that's immensely faster, but works perhaps in a slightly different way.
        /// </example>
        /// <remarks>
        /// Don't forget - it's not a crime (per se...) to introduce a bit of logic in the adapter. All good intentions... So we might do a bit of caching, etc., if this suits our purpose.
        /// </remarks>
        private static void Main()
        {
            // Create adapter and place a request
            ITarget target = new Adapter();
            target.Request();

            // Wait for user
            Console.ReadKey();
        }
    }
}