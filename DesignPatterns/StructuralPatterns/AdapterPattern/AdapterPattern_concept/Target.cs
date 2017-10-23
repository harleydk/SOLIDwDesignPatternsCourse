using System;

namespace DesignPatterns.Adapter.Structural
{
    /// <summary>
    /// The 'Target' class
    /// </summary>
    internal class Target : ITarget
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }
}