namespace DecoratorPattern
{
    public sealed class SpecialOfferMember(int extraPoints) : IMember
    {
        private readonly int _extraPoints;
        private int _points;
        private string _name;

        public int Points
        {
            get
            {
                return _points + _extraPoints;
            }
            set
            {
                _points = value;
            }
        }

        public string Name { get => _name; set => _name = value; }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}