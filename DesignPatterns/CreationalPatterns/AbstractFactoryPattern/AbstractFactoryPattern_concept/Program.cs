using System;

namespace DesignPatterns.Abstract.Structural
{
    public sealed class Program
    {
        /// <summary>
        /// The Abstract Factory pattern defines an abstract 'factory' class, with the responsibility of creating objects of classes that are related in regards to a common domain.
        /// </summary>
        public static void Main()
        {
            // Abstract factory #1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new(factory1);
            client1.Run();

            // Abstract factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new(factory2);
            client2.Run();

            // Wait for user input
            Console.ReadKey();
        }
    }
}