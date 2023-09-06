namespace DesignPatterns.Adapter.Structural
{
    /// <summary>
    /// The 'Adapter' class - wraps the Adaptee (class to be adapted, i.e.) and calls its methods, though presents itself as an ITarget
    /// </summary>
    internal class Adapter : ITarget
    {
        private readonly ISubjectForAdaption _adaptee = new SubjectForAdaption();

        public void Request()
        {
            // Possibly do some other work and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }
}