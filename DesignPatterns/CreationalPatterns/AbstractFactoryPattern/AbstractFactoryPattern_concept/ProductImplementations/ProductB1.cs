using System;

namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }
}