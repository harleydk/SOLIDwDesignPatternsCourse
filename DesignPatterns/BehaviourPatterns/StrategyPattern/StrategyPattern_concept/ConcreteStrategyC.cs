using System;

namespace StrategyPattern
{
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyC : IStrategy
    {
        public void ExecuteStrategy()
        {
            Console.WriteLine(
              "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }
}