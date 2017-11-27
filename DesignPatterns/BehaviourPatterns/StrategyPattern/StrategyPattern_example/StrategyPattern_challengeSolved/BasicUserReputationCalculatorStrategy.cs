namespace StrategyPattern
{
    public class BasicUserReputationCalculateStrategy : IDatingUserReputationStrategy
    {
        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 2;
        }
    }
}