namespace CompositePattern_concept
{
    /// <summary>
    /// The 'IComponent' abstract class
    /// </summary>
    internal interface IComponent
    {
        void Add(IComponent c);

        void Remove(IComponent c);

        void Display(int depth);
    }
}