using System;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class PersistentBeepAlarm : IAlarm
    {
        public void RaiseAlarm()
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