namespace DecoratorPattern
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class ComponentDecoratorBase(Component component) : Component
    {
        protected Component _component = component;

        public override void Operation()
        {
            if (_component != null)
            {
                _component.Operation();
            }
        }
    }
}