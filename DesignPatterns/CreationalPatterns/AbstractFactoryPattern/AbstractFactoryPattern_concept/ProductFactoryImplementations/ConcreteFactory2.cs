namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    internal class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}