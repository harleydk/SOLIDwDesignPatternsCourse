namespace DecoratorPattern
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class ComponentDecoratorBase : Component
    {
        protected Component _component;

        public ComponentDecoratorBase(Component component)
        {
            _component = component;
        }

        public override void Operation()
        {
            if (_component != null)
            {
                _component.Operation();
            }
        }
    }
}