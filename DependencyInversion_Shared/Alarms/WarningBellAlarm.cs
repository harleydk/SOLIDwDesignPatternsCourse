using System;

namespace DependencyInversion
{
    public sealed class WarningBellAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.Beep();
        }
    }
}