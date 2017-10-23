using System;

namespace DecoratorPattern
{
    public static class Program
    {
        /// <summary>
        /// The Decorator Design Pattern aims to add functionality to existing classes. This is done by implementing a decorator base-class, that holds the classes to be decorated and executes its methods, thus enabling a chain of calls.
        /// </summary>
        /// <example>
        /// Real life uses include...
        ///     - adding filters-criterias to filter a data-set
        ///     - adding calculations to models - fx meteological maps
        ///     - decorating a command with others, thus creating a chain of commands to be executed
        /// </example>
        private static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA(c);
            ConcreteDecoratorB d2 = new ConcreteDecoratorB(d1);

            d2.Operation();

            // Wait for user
            Console.ReadKey();
        }
    }
}