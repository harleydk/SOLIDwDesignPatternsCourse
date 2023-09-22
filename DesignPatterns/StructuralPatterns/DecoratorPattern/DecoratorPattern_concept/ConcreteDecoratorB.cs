using System;

namespace DecoratorPattern
{
    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    internal class ConcreteDecoratorB(Component component) : ComponentDecoratorBase(component)
    {
        
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        private void AddedBehavior()
        {
            Console.WriteLine("Behaviour was added.");
        }
    }
}