using System.Diagnostics;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class EnhancedDisplayAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            // we'll just pretend to raise an alarm here.
            Debug.WriteLine("AN ALARM WAS RAISED, GOD DAMMIT!!!");
        }
    }
}