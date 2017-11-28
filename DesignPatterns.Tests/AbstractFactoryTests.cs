using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbstractFactoryPattern;

namespace DesignPatterns.Tests
{
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void AbstractFactory_TestCanCreateBasicAuthenticator()
        {
            // arrange
            AbstractFactoryPattern.ISecurityProviderFactory basicSecurityProviderFactory= new AbstractFactoryPattern.BasicUserSecurityProviderFactory();

            // act
            var authenticator = basicSecurityProviderFactory.CreateAuthenticator();

            // assert
            Assert.IsInstanceOfType(authenticator, typeof(BasicUserAuthenticator));
        }
    }
}
