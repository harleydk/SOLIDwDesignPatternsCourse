using TemplatePattern;

namespace TemplatePattern_challengeSolved
{
    internal class Program
    {
        /// <summary>
        /// By introducing an abstract class with a template method that defines a default skeleton for notifying members, and allows the implementing classes to override certain steps, we have a more maintainable way of handling these things.
        /// </summary>
        private static void Main()
        {
            Member bruceFreeMember = Member.CreateMember("Bruce Willis", "1-800-diehard", MemberType.FreeUser);
            FreeMemberNotification freeMemberNotificator = new(bruceFreeMember);
            freeMemberNotificator.NotifyMember();

            Member clintPayingUser = Member.CreateMember("Clint Eastwood", "1-800-mkemydy", MemberType.PayingUser);
            PayingMemberNotification payingMemberNotificator = new(clintPayingUser);
            payingMemberNotificator.NotifyMember();

            // What did we achieve? We re-factored our code and made a case for maximum code re-use and flexibility - and later maintenance-benefits.
        }
    }
}