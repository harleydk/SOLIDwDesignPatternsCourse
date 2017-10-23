namespace DecoratorPattern
{
    public class Member : IMember
    {
        // Basic regular-member class.
        public virtual string Name { get; set; }

        public virtual int Points { get; set; }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}