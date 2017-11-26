namespace DecoratorPattern
{
    // Here's the pattern in action. We derive a class from the member-class, 
    // and hold an instance of the memberbase as a variable. We thus create a 'master decorator'.
    public abstract class MemberDecoratorbase : IMember
    {
        protected IMember _member;

        public MemberDecoratorbase(IMember member)
        {
            this._member = member;
        }

        public virtual string Name
        {
            get
            {
                return _member.Name;
            }
            set
            {
                _member.Name = value;
            }
        }

        public virtual int Points
        {
            get
            {
                return _member.Points;
            }
            set
            {
                _member.Points = value;
            }
        }

        public virtual string GetMemberStatus()
        {
            return $"{Name}, {Points} points.";
        }
    }
}