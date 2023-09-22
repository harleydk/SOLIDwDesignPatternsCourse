using System;

namespace DecoratorPattern
{
    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    internal class ConcreteDecoratorA(Component component) : ComponentDecoratorBase(component)
    {
       
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }
}