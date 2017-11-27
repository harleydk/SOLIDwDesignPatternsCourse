namespace TemplatePattern
{
    public sealed class PayingMemberNotification : MemberNotificationBase
    {
        public PayingMemberNotification(Member memberToNotify) : base(memberToNotify)
        {
        }

        public override bool ShouldNotifyMemberBySMS()
        {
            return true;
        }
    }
}