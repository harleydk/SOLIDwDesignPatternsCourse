using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests
{
    /// <summary>
    /// Summary description for StrategyTests
    /// </summary>
    [TestClass]
    public class StrategyTests
    { 
        [TestMethod]
        public void StrategyPattern_TestCanSelectStrategy()
        {
            // arrange
            StrategyPattern.IDatingUserReputationStrategy datingUserReputationStrategy = new StrategyPattern.BasicUserReputationCalculateStrategy();
            StrategyPattern.DatingUser datingUser = new();
            datingUser.SetReputationCalculatorStrategy(datingUserReputationStrategy) ;
            datingUser.NumberOfAnsweredQuestions = 10;
            datingUser.UserReputation = StrategyPattern.UserReputationEnum.BasicUserReputation;


            // act
            datingUserReputationStrategy.CalculateReputation(10);


            // assert
        }
    }
}
