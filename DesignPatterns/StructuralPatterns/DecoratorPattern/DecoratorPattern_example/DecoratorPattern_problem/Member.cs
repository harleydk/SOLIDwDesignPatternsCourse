namespace DecoratorPattern
{
    public class Member : IMember
    {
        // Basic regular-member class.
        public string Name { get; set; }

        public int Points { get; set; }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}