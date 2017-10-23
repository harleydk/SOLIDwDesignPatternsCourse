namespace StrategyPattern
{
    public class SuperUserReputationCalculator : IDatingUserReputationStrategy
    {
        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 10;
        }
    }
}