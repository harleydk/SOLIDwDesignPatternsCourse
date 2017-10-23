namespace DecoratorPattern
{
    public class Member : IMember
    {
        // Basic regular-member class.
        public virtual string Name { get; set; }

        public virtual int Points { get; set; }

        public virtual string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }

        internal static Member CreateMember(string name, int points)
        {
            Member newMember = new Member()
            {
                Name = name,
                Points = points
            };
            return newMember;
        }
    }
}