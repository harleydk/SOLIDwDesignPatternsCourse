using System;

namespace DecoratorPattern
{
    /// <summary>
    /// The 'ConcreteComponent' class, that we'll later decorate with additional behaviours.
    /// </summary>
    internal class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }
}