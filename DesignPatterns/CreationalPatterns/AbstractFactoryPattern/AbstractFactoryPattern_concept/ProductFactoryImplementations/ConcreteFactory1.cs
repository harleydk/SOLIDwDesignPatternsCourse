namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    internal class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
}