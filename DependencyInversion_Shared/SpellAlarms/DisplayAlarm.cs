using System.Diagnostics;

namespace DependencyInversion
{
    public sealed class DisplayAlarm : ISpellAlarm
    {
        public void RaiseSpellAlarm()
        {
            // we'll just pretend to raise an alarm here.
            Debug.WriteLine("An alarm was raised");
        }
    }
}