using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CompositePattern_concept
{
    /// <summary>
    /// The 'Composite' class
    /// </summary>
    internal class Composite : IComponent
    {
        private readonly List<IComponent> _children = new();

        // Constructor
        public Composite()
        {
        }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IComponent component)
        {
            _children.Remove(component);
        }

        public void Display(int depth)
        {
            Debug.WriteLine(new String('-', depth));

            // Recursively display child nodes
            foreach (IComponent component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }
}