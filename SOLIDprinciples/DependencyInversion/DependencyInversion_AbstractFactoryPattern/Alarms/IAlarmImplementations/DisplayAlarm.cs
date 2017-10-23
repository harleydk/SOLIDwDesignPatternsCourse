using System.Diagnostics;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class DisplayAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            // we'll just pretend to raise an alarm here.
            Debug.WriteLine("An alarm was raised");
        }
    }
}