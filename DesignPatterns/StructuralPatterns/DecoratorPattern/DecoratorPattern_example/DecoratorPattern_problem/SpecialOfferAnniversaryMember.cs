namespace DecoratorPattern
{
    public sealed class SpecialOfferAnniversaryMember(int extraPoints) : IMember
    {
        private const int ANNIVERSARY_MEMBER_POINTS = 1000;


        private int _points;
        private string _name;

        public string Name
        {
            get
            {
                // Add 'is anniversary' to the name, if that's indeed the case.
                bool asAnniversary = this.hasAnniversary(_name) ? true : false;
                _name = asAnniversary ? _name + " - anniversary." : Name;
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Points { get => _points + extraPoints + ANNIVERSARY_MEMBER_POINTS; set => _points = value; }

        private bool hasAnniversary(string name)
        {
            bool hasAnniversary = name == "Clint Eastwood" ? true : false;
            return hasAnniversary;
        }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}