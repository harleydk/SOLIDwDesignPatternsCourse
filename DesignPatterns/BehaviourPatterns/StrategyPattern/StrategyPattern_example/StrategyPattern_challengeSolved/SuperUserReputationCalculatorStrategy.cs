namespace StrategyPattern
{
    public class SuperUserReputationCalculatorStrategy : IDatingUserReputationStrategy
    {
        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 10;
        }
    }
}