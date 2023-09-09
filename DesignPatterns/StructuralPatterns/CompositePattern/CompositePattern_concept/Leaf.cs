using System;
using System.Diagnostics;

namespace CompositePattern_concept
{
    /// <summary>
    /// The 'Leaf' or 'node' class
    /// </summary>
    internal class Leaf : IComponent
    {
        private readonly string _name;

        // Constructor
        public Leaf(string name)
        {
            _name = name;
        }

        public void Add(IComponent c)
        {
            Debug.WriteLine("Cannot add to a leaf");
        }

        public void Remove(IComponent c)
        {
            Debug.WriteLine("Cannot remove from a leaf");
        }

        public void Display(int depth)
        {
            Debug.WriteLine(new String('-', depth) + _name);
        }
    }
}