using StrategyPattern;

namespace StrategyPattern_challengeSolved
{
    public static class Program
    {
        /// <summary>
        /// We cook up a function, SetReputationCalculatorStrategy(), that allows us to insert an appropriate strategy-implementation at runtime.
        /// </summary>
        public static void Main()
        {
            DatingUser someUser = new DatingUser()
            {
                NumberOfAnsweredQuestions = 3
            };
            someUser.SetReputationCalculatorStrategy(new BasicUserReputationCalculator());
            System.Diagnostics.Debug.WriteLine(someUser.CalculateReputation());

            someUser.SetReputationCalculatorStrategy(new SuperUserReputationCalculator());
            System.Diagnostics.Debug.WriteLine(someUser.CalculateReputation());

            // What did we achieve? We factored out the strategies, factored out that which changed and
            // thus made our code more maintainable and flexible. We are now easily able to implement further strategies.
        }
    }
}