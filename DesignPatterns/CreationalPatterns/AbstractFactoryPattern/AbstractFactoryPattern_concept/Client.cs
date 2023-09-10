namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    internal class Client
    {
        private readonly AbstractProductA _abstractProductA;
        private readonly AbstractProductB _abstractProductB;

        // Constructor
        public Client(AbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}