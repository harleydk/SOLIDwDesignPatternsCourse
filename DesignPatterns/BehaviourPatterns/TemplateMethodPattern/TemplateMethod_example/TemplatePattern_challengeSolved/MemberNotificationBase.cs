using System;
using System.Diagnostics;

namespace TemplatePattern
{
    // The Template Pattern lets us define a series of common steps, deferring some steps to sub-classes.
    // Let's redo the notifications in the style of the pattern:

    // Here's the pattern in action. An abstract class defines the 'NotifyMember()-skeleton', that we'll later sub-class.
    public abstract class MemberNotificationBase : IMemberNotification
    {
        protected Member _memberToNotify;

        protected MemberNotificationBase(Member memberToNotify)
        {
            _memberToNotify = memberToNotify;
        }

        // Here's our template-method. Includes all functionality from the two implementations, with an option - the 'hook' method - to stray from the template if need be.
        public void NotifyMember()
        {
            SendNotificationEmail();
            if (NotifyMemberBySMS())
            {
                SMSnotifyOfNotification();
            }
            MarkMemberAsNotified();
        }

        public void MarkMemberAsNotified()
        {
            _memberToNotify.SetNotificationDate(DateTime.Now);
        }

        private void SMSnotifyOfNotification()
        {
            Debug.WriteLine("Sending an sms to " + _memberToNotify.MobilePhoneNumber);
        }

        // virtual allows us to override this. we don't _have_ to, as with abstract. This is called a 'hook'.
        public virtual bool NotifyMemberBySMS() // 'Hook' function
        {
            return false;
        }

        public void SendNotificationEmail()
        {
            Debug.WriteLine("Sending a regular notification e-mail");
        }
    }
}