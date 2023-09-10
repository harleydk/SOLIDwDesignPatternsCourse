using StrategyPattern;
using System.Diagnostics;

namespace StrategyPattern_challengeSolved
{
    public static class Program
    {
        /// <summary>
        /// We cook up a function, SetReputationCalculatorStrategy(), that allows us to add an appropriate strategy-implementation at runtime.
        /// </summary>
        public static void Main()
        {
            DatingUser someUser = new()
            {
                NumberOfAnsweredQuestions = 3,
                UserReputation = UserReputationEnum.BasicUserReputation
            };

            UserReputationStratategySelector userReputationStrategySelector = new();
            IDatingUserReputationStrategy datingUserReputationStrategy = userReputationStrategySelector.GetUserReputationStrategy(someUser.UserReputation);
            someUser.SetReputationCalculatorStrategy(datingUserReputationStrategy);
            Debug.WriteLine(someUser.CalculateReputation());

            DatingUser someSuperUser = new()
            {
                NumberOfAnsweredQuestions = 3,
                UserReputation = UserReputationEnum.SuperUserReputation
            };

            datingUserReputationStrategy = userReputationStrategySelector.GetUserReputationStrategy(someSuperUser.UserReputation);
            someSuperUser.SetReputationCalculatorStrategy(datingUserReputationStrategy);
            Debug.WriteLine(someSuperUser.CalculateReputation());

            // What did we achieve? We factored out the strategies, factored out that which changed and
            // thus made our code more maintainable and flexible. We are now easily able to implement further strategies.

            // What else can we do? Well, we could inject the strategy directly into the Dating-user constructor, how about that.

            // We could inject the entire strategy-selector into the dating-user constructor, even. So we might change the users' 
            // reputation-enum at runtime, and the class would know to get the proper strategy all by itself.
        }
    }
}