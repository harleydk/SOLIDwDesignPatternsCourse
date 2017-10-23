using TemplatePattern;

namespace TemplatePattern_challenge
{
    /// <summary>
    /// Here we have two members, of different types, with almost identical ways of being notified.
    /// Almost - but not quite.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            Member bruceFreeMember = Member.CreateMember("Bruce Willis", "1-800-diehard", MemberType.FreeUser);
            FreeMemberNotification freeMemberNotificator = new FreeMemberNotification(bruceFreeMember);
            freeMemberNotificator.NotifyMember();

            Member clintPayingUser = Member.CreateMember("Clint Eastwood", "1-800-mkemydy", MemberType.PayingUser);
            PayingMemberNotification payingMemberNotificator = new PayingMemberNotification(clintPayingUser);
            payingMemberNotificator.NotifyMember();

            // This works, but... Feels much like we should be able to re-use some code.
            // The template pattern helps us in this.

            // Lab-challenge: rewrite to utilize the Template Pattern.
        }
    }
}