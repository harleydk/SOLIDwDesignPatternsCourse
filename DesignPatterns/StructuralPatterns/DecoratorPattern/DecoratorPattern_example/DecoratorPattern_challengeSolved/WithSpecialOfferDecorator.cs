using System.Diagnostics;

namespace DecoratorPattern
{
    //
    public sealed class WithSpecialOfferDecorator : MemberDecoratorbase
    {
        private int _extraPoints;

        public override int Points
        {
            get
            {
                Debug.WriteLine("WithSpecialOfferDecorator getPoints() called");
                return base.Points + _extraPoints;
            }
            set
            {
                base.Points = value;
            }
        }

        public WithSpecialOfferDecorator(IMember member, int extraPoints) : base(member)
        {
            _extraPoints = extraPoints;
        }
    }
}