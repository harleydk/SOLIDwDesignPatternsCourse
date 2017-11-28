using StrategyPattern;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern_challengeSolved
{
    public class UserReputationStratategySelector
    {
        private List<IDatingUserReputationStrategy> _userReputationStrategies;

        public UserReputationStratategySelector()
        {
            _userReputationStrategies = new List<IDatingUserReputationStrategy>();

            IDatingUserReputationStrategy basicUserReputationStrategy = new BasicUserReputationCalculateStrategy();
            _userReputationStrategies.Add(basicUserReputationStrategy);

            IDatingUserReputationStrategy superUserReputationStrategy = new SuperUserReputationCalculatorStrategy();
            _userReputationStrategies.Add(superUserReputationStrategy);

            // Note, we wouldn't normally hook up strategies like this, rather use DI for this.
        }

        public IDatingUserReputationStrategy GetUserReputationStrategy(UserReputationEnum userReputation)
        {
            IDatingUserReputationStrategy firstMatchingStrategy = _userReputationStrategies.First(
                reputationStrategy => reputationStrategy.IsStrategyMatch(userReputation));
            return firstMatchingStrategy;
        }

    }
}