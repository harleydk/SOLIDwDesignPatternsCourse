using System.Diagnostics;

namespace StrategyPattern
{
    public sealed class DatingUser
    {
        public UserReputation userReputation { get; set; }

        public int NumberOfAnsweredQuestions { get; set; }

        public int CalculateReputation()
        {
            Debug.Assert(NumberOfAnsweredQuestions > 0, "number of answered questions should be > 0");
            int calculatedReputation = 0;
            switch (userReputation)
            {
                // this is the culprit - we're having to switch between user-reputations. Breaks with what principle...?
                case UserReputation.BasicUserReputation:
                    calculatedReputation = NumberOfAnsweredQuestions * 2;
                    break;

                case UserReputation.SuperUserReputation:
                    calculatedReputation = NumberOfAnsweredQuestions * 10;
                    break;
            }

            Debug.Assert(calculatedReputation > 0, "calculated reputation should be > 0");
            return calculatedReputation;
        }
    }
}