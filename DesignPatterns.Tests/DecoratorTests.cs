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
            WithSpecialOfferDecorator firstSpecialDealForArnold = new WithSpecialOfferDecorator(multipleDealsArnold, 500);
            WithSpecialOfferDecorator secondSpecialDealForArnold = new WithSpecialOfferDecorator(firstSpecialDealForArnold, 500);
            WithSpecialOfferDecorator thirdSpecialDealForArnold = new WithSpecialOfferDecorator(secondSpecialDealForArnold, 500);
            var points = thirdSpecialDealForArnold.Points;

            // assert
            Assert.AreEqual(points, 1800);
        }
    }
}
