namespace StrategyPattern
{
    // Here's the interface for our strategies
    public interface IDatingUserReputationStrategy
    {
        int CalculateReputation(int numberOfAnsweredQuestions);
    }
}