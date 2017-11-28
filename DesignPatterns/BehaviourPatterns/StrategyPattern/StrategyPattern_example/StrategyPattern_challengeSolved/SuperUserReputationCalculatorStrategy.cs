namespace StrategyPattern
{
    public class SuperUserReputationCalculatorStrategy : IDatingUserReputationStrategy
    {
        public bool IsStrategyMatch(UserReputationEnum userReputationEnum)
        {
            return userReputationEnum == UserReputationEnum.SuperUserReputation;
        }

        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 10;
        }
    }
}