using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests
{
    [TestClass]
    public class TemplatePattern_tests
    {
        [TestMethod]
        public void TemplatePattern_testShouldNotifPayingMemberBySms()
        {
            // arrange
            TemplatePattern.Member member = TemplatePattern.Member.CreateMember("Clinet", "555-1234-132>", TemplatePattern.MemberType.PayingUser);
            TemplatePattern.MemberNotificationBase memberNotification = new TemplatePattern.PayingMemberNotification(member);

            // act
            bool shouldNotifyPayMemberBySms = memberNotification.ShouldNotifyMemberBySMS();

            // assert
            Assert.IsTrue(shouldNotifyPayMemberBySms);
        }

        [TestMethod]
        public void TemplatePattern_testShouldNotNotifPayingMemberBySms()
        {
            // arrange
            TemplatePattern.Member member = TemplatePattern.Member.CreateMember("Clinet", "555-1234-132>", TemplatePattern.MemberType.PayingUser);
            TemplatePattern.MemberNotificationBase memberNotification = new TemplatePattern.FreeMemberNotification(member);

            // act
            bool shouldNotifyPayMemberBySms = memberNotification.ShouldNotifyMemberBySMS();

            // assert
            Assert.IsFalse(shouldNotifyPayMemberBySms);
        }
    }
}
