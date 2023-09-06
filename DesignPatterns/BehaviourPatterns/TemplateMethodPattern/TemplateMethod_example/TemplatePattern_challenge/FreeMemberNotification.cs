using System;
using System.Diagnostics;

namespace TemplatePattern
{
    public sealed class FreeMemberNotification : IMemberNotification
    {
        private Member _memberToNotify;

        public FreeMemberNotification(Member memberToNotify)
        {
            _memberToNotify = memberToNotify;
        }

        public void MarkMemberAsNotified()
        {
            _memberToNotify.SetNotificationDate(DateTime.Now);
        }

        // Here's the important bit - pay heed to the signatures.
        public void NotifyMember()
        {
            SendNotificationEmail();
            MarkUserAsNotified();
        }

        private void MarkUserAsNotified()
        {
            _memberToNotify.SetNotificationDate(DateTime.Now);
        }

        private void SendNotificationEmail()
        {
            Debug.WriteLine("Sending a regular notification e-mail");
        }
    }
}