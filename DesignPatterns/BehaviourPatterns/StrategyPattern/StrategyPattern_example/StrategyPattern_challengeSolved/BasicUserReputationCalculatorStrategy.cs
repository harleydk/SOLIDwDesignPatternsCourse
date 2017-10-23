namespace StrategyPattern
{
    public class BasicUserReputationCalculator : IDatingUserReputationStrategy
    {
        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 2;
        }
    }
}