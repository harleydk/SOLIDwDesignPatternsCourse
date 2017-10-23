namespace DesignPatterns.Abstract.Structural
{
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();

        public abstract AbstractProductB CreateProductB();
    }
}