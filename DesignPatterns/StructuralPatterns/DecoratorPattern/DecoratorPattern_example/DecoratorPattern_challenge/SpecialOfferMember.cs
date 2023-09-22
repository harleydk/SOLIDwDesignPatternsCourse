namespace DecoratorPattern
{
    /// <summary>
    /// TODO: Let this derive from a decorator-base class instead, so we can decorate a target-class with functionality instead of having to instantiate it.
    /// </summary>
    public sealed class SpecialOfferMember (int extraPoints): IMember
    {
        private int _points;
        private string _name;

        public int Points { get => _points + extraPoints; set => _points = value; }

        public string Name { get => _name; set => _name = value; }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}