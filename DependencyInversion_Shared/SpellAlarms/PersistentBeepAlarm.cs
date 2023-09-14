using System;

namespace DependencyInversion
{ 
    public sealed class PersistentBeepAlarm : ISpellAlarm
    {
        public void RaiseSpellAlarm()
        {
            int i = 0;
            do
            {
                Console.Beep();
                i++;
            }
            while (i < 5);
        }
    }
}