namespace StrategyPattern
{
    // Here's the interface for our strategies
    public interface IDatingUserReputationStrategy
    {
        bool IsStrategyMatch(UserReputationEnum userReputationEnum);

        int CalculateReputation(int numberOfAnsweredQuestions);
    }
}