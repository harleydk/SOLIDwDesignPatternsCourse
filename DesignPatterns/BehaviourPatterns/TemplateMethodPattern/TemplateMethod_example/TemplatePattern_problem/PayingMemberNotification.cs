using System;
using System.Diagnostics;

namespace TemplatePattern
{
    public sealed class PayingMemberNotification : IMemberNotification
    {
        private Member _memberToNotify;

        public PayingMemberNotification(Member memberToNotify)
        {
            _memberToNotify = memberToNotify;
        }

        // Here's the important bit, part 2 - one extra method, though.
        public void NotifyMember()
        {
            SendNotificationEmail();
            SendNotificationSMS();
            MarkMemberAsNotified();
        }

        private void SendNotificationSMS()
        {
            Debug.WriteLine("An sms was sent to " + _memberToNotify.MobilePhoneNumber);
        }

        private void SendNotificationEmail()
        {
            Debug.WriteLine("Sending an enhanced notification e-mail");
        }

        public void MarkMemberAsNotified()
        {
            _memberToNotify.SetNotificationDate(DateTime.Now);
        }
    }
}