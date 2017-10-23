using System;
using System.Diagnostics;
using TemplatePattern;

namespace TemplatePattern_challenge
{

    public static class Program
    {
        /// <summary>
        /// Problem: We need to notify our members, and mark them as notified. This is implemented via their implementations of the NotifyMember() method on the IMemberNotification interface. However, the user of type PayingUser also get an SMS. Solve the problem by implementing a template-method
        /// </summary>
        /// <remarks>
        /// Start by implementing an abstract base-class, that holds the combined functionality from the two member-notification implementations.
        /// </remarks>
        public static void Main()
        {
            Member bruceFreeMember = Member.CreateMember("Bruce Willis", "1-800-diehard", MemberType.FreeUser);
            FreeMemberNotification freeMemberNotificator = new FreeMemberNotification(bruceFreeMember);
            freeMemberNotificator.NotifyMember();

            Member clintPayingUser = Member.CreateMember("Clint Eastwood", "1-800-mkemydy", MemberType.PayingUser);
            PayingMemberNotification payingMemberNotificator = new PayingMemberNotification(clintPayingUser);
            payingMemberNotificator.NotifyMember();
        }
    }
}