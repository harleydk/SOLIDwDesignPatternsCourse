namespace StrategyPattern
{
    /// <summary>
    /// The 'Context' class
    /// </summary>
    internal class Context
    {
        private IStrategy _strategy;

        // Constructor
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextStrategyExecution()
        {
            _strategy.ExecuteStrategy();
        }
    }
}