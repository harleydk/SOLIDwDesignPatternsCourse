using System;

namespace DesignPatterns.Adapter.Structural
{
    /// <summary>
    /// The 'Adaptee' class - that we need to adapt, in order to function with our other components.
    /// </summary>
    internal class SubjectForAdaption : ISubjectForAdaption
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}