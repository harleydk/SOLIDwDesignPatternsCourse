namespace StrategyPattern
{
    public class BasicUserReputationCalculateStrategy : IDatingUserReputationStrategy
    {
        public bool IsStrategyMatch(UserReputationEnum userReputationEnum)
        {
            return userReputationEnum == UserReputationEnum.BasicUserReputation;
        }

        public int CalculateReputation(int numberOfAnsweredQuestions)
        {
            return numberOfAnsweredQuestions * 2;

        }
    }
}