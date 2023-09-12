namespace TemplatePattern
{
    public struct Member
    {
        public string Name { get; private set; }

        public MemberType MemberType { get; private set; }

        public string MobilePhoneNumber { get; private set; }

        public DateTime? NotificationDate { get; private set; }

        private Member(string name, string mobileNumber, MemberType memberType, DateTime? memberNotificationDate = null)
        {
            Name = name;
            MobilePhoneNumber = mobileNumber;
            MemberType = memberType;

            NotificationDate = memberNotificationDate;
        }

        public static Member CreateMember(string name, string mobilePhoneNumber, MemberType memberType)
        {
            Member newMember = new(name, mobilePhoneNumber, memberType);
            return newMember;
        }

        public void SetNotificationDate(DateTime notificationDate)
        {
            NotificationDate = notificationDate;
        }
    }
}