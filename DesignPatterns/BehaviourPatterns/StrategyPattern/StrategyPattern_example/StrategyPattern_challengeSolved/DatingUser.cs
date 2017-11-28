using System.Diagnostics;

namespace StrategyPattern
{
    public sealed class DatingUser
    {
        // This is a placeholder for our selected strategy...
        private IDatingUserReputationStrategy _userReputationStrategy;

        public UserReputationEnum UserReputation { get; set; }

        public int NumberOfAnsweredQuestions { get; set; }

        public void SetReputationCalculatorStrategy(IDatingUserReputationStrategy userReputationStrategy)
        {
            _userReputationStrategy = userReputationStrategy;
        }

        public int CalculateReputation()
        {
            Debug.Assert(_userReputationStrategy != null, "_userReputationStrategy should not be null at this point.");
            return _userReputationStrategy.CalculateReputation(NumberOfAnsweredQuestions);
        }
    }
}