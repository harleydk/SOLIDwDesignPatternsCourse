using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern;

namespace DesignPatterns.Tests
{
    [TestClass]
    public class DecoratorTests
    {
        [TestMethod]
        public void DecoratorTests_CanDecorate()
        {
            // arrange
            Member multipleDealsArnold = Member.CreateMember("Arnold Schwarzenegger", 300);

            // act
            WithSpecialOfferDecorator firstSpecialDealForArnold = new(multipleDealsArnold, 500);
            WithSpecialOfferDecorator secondSpecialDealForArnold = new(firstSpecialDealForArnold, 500);
            WithSpecialOfferDecorator thirdSpecialDealForArnold = new(secondSpecialDealForArnold, 500);
            int points = thirdSpecialDealForArnold.Points;

            // assert
            Assert.AreEqual(points, 1800);
        }
    }
}
