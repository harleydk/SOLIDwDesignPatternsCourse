using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests
{
    [TestClass]
    public class FacadeTests
    {
        [TestMethod]
        public void Facade_TestCanGetAndValidateAddress()
        {
            // arrange
            string testUserName = "foobarUserName";
            FacadePattern.UserRelocationProcessingFacade userRelocationProcessingFacade = new FacadePattern.UserRelocationProcessingFacade(testUserName);

            // act
            bool canGetAndValidateAddress = userRelocationProcessingFacade.CanGetAndValidateUserAddress();

            // assert
            Assert.IsTrue(canGetAndValidateAddress);
        }

    }
}
