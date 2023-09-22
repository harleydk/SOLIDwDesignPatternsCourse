namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    internal class Client(AbstractFactory factory)
    {
        private readonly AbstractProductA _abstractProductA = factory.CreateProductA();
        private readonly AbstractProductB _abstractProductB = factory.CreateProductB();

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}