using System;

namespace StrategyPattern
{
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyA : IStrategy
    {
        public void ExecuteStrategy()
        {
            Console.WriteLine(
              "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
}