using System.Diagnostics;

namespace DependencyInversion
{
    public sealed class EnhancedDisplayAlarm : ISpellAlarm
    {
        public void RaiseSpellAlarm()
        {
            // we'll just pretend to raise an alarm here.
            Debug.WriteLine("AN ALARM WAS RAISED, GOD DAMMIT!!!");
        }
    }
}