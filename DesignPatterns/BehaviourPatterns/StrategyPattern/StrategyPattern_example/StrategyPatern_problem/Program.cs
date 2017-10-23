using StrategyPattern;
using System.Diagnostics;

namespace StrategyPatern_problem
{
    public sealed class Program
    {
        /// <summary>
        /// Dilemma: we need to calculate a 'user reputation' for our dating service users, based on which type of member they are. How do we go about that in the best, most flexible way? In the below example, the DatingUser-class shifts between types to accomodate different UserReputation values.
        /// </summary>
        private static void Main()
        {
            DatingUser someUser = new DatingUser();

            someUser.NumberOfAnsweredQuestions = 3;
            someUser.userReputation = UserReputation.BasicUserReputation;

            int calculatedReputation = someUser.CalculateReputation();

            Debug.Assert(calculatedReputation > 0, "user's calculated reputation-score should be > 0");
            Debug.WriteLine($"User's calculated reputation-score: {calculatedReputation}");

            // Well, this works, but What if we need to calculate reputation by an all new reputation type? "SuperUserReputation"?
            // We'd have to go into the DatingUser-class and modify it.
        }
    }
}