using System;

namespace DependencyInversion
{
    public sealed class WarningBellAlarm : ISpellAlarm
    {
        public void RaiseSpellAlarm()
        {
            Console.Beep();
        }
    }
}