namespace TemplatePattern
{
    public sealed class PayingMemberNotification(Member memberToNotify) : MemberNotificationBase(memberToNotify)
    {
        public override bool ShouldNotifyMemberBySMS()
        {
            return true;
        }
    }
}