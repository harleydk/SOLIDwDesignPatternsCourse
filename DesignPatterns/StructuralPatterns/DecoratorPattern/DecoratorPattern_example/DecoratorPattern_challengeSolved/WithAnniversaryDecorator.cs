using System.Diagnostics;

namespace DecoratorPattern
{
    public class WithAnniversaryDecorator(IMember member) : MemberDecoratorbase(member)
    {
        private const int ANNIVERSARY_MEMBER_POINTS = 1000;

       

        public override int Points
        {
            get
            {
                Debug.WriteLine("WithAnniversaryDecorator getPoints() called");
                return base.Points + ANNIVERSARY_MEMBER_POINTS;
            }
            set
            {
                base.Points = value;
            }
        }

        public override string Name
        {
            get
            {
                bool asAnniversary = this.hasAnniversary(base.Name) ? true : false;
                string name = asAnniversary ? base.Name + " - anniversary." : base.Name;
                return name;
            }
            set
            {
                base.Name = value;
            }
        }

        private bool hasAnniversary(string name)
        {
            bool hasAnniversary = name == "Clint Eastwood" ? true : false;
            return hasAnniversary;
        }
    }
}