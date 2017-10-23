namespace DecoratorPattern
{
    /// <summary>
    /// TODO: Let this derive from a decorator-base class instead, so we can decorate a target-class with functionality instead of having to instantiate it.
    /// </summary>
    public class AnniversaryMember : IMember
    {
        private const int ANNIVERSARY_MEMBER_POINTS = 1000;
        private int _points;
        private string _name;

        public int Points
        {
            get
            {
                return _points + ANNIVERSARY_MEMBER_POINTS;
            }
            set
            {
                _points = value;
            }
        }

        public string Name
        {
            get
            {
                // add 'is anniversary to the name, if that's indeed the case.
                bool asAnniversary = this.hasAnniversary(_name) ? true : false;
                _name = asAnniversary ? _name + " - anniversary." : Name;
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }

        private bool hasAnniversary(string name)
        {
            bool hasAnniversary = name == "Clint Eastwood" ? true : false;
            return hasAnniversary;
        }
    }
}