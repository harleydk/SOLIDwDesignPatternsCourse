namespace TemplatePattern
{
    // We need to send notifications to the members - different notifications for different users.
    // So, it's the same procedure, with just a few differences.

    public enum MemberType
    {
        FreeUser,
        PayingUser
    }
}
