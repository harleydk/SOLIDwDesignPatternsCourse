using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdapterPattern;
using System.Linq;

namespace DesignPatterns.Tests
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void AdapterPattern_TestCanNotAccessOldmethod()
        {
            // arrange
            ThirdPartyAuthenticatorAdapter thirdPartyAuthenticatorAdapter = new();

            // act
            var methods = thirdPartyAuthenticatorAdapter.GetType().GetMethods();
            bool hasStillOldMethod = methods.Any(method => method.Name == "TryToAuthenciate");

            // assert
            Assert.IsFalse(hasStillOldMethod);
        }
    }
}
