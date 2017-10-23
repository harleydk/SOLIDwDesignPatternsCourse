namespace DecoratorPattern
{
    public interface IMember
    {
        string Name { get; set; }

        int Points { get; set; }

        string GetMemberStatus();
    }
}