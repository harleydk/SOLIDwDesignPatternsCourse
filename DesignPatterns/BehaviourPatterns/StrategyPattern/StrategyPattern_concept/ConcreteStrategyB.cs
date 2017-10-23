using System;

namespace StrategyPattern
{
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyB : IStrategy
    {
        public void ExecuteStrategy()
        {
            Console.WriteLine(
              "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
}