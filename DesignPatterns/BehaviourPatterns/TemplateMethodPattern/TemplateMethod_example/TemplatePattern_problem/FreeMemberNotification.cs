using System;
using System.Diagnostics;

namespace TemplatePattern
{
    public sealed class FreeMemberNotification(Member memberToNotify) : IMemberNotification
    {
        public void MarkMemberAsNotified()
        {
            memberToNotify.SetNotificationDate(DateTime.Now);
        }

        // Here's the important bit - pay heed to the signatures.
        public void NotifyMember()
        {
            SendNotificationEmail();
            MarkUserAsNotified();
        }

        private void MarkUserAsNotified()
        {
            memberToNotify.SetNotificationDate(DateTime.Now);
        }

        private void SendNotificationEmail()
        {
            Debug.WriteLine("Sending a regular notification e-mail");
        }
    }
}