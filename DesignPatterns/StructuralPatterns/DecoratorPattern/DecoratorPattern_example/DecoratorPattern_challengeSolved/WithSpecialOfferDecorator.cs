namespace DecoratorPattern
{
    // Note how we only override that which we actually need to override. 
    public sealed class WithSpecialOfferDecorator : MemberDecoratorbase
    {
        private readonly int _extraPoints;

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