using System;

namespace DecoratorPattern
{
    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    internal class ConcreteDecoratorA : ComponentDecoratorBase
    {
        public ConcreteDecoratorA(Component component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
}