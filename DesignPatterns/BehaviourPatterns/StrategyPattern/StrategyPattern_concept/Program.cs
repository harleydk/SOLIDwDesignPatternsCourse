using System;

namespace StrategyPattern
{
    /// <summary>
    /// The strategy pattern allows us to substitute one behaviour/algorithm with another at runtime.
    /// </summary>
    /// <example>
    /// Real-life uses include...
    ///     - executing a different stored procedure based on changing types - fx for conversion projects
    ///     - selecting a calculation based on changing run-time criteria - fx updating a meteorological model based on real-time data, or calculating player statistics for a computer-game based on a player's held weapon of choice.
    /// </example>
    /// <remarks>
    /// Candidates for a strategy-pattern imlementation are algorithms that frequently added/changed. If the circumstances seldom change, we would not use this pattern. For example, implementing a strategy to change database-providers based on the time of day would probably not be the best use-case for this design patterns, as this is likely not an often-changing scenario.
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextStrategyExecution();

            context = new Context(new ConcreteStrategyB());
            context.ContextStrategyExecution();

            context = new Context(new ConcreteStrategyC());
            context.ContextStrategyExecution();

            // Wait for user
            Console.ReadKey();
        }
    }
}