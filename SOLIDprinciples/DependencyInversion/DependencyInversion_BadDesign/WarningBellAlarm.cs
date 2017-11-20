using System;

namespace DependencyInversion_BadDesign
{
    public sealed class WarningBellAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.Beep(5000, 1000);
        }
    }
}