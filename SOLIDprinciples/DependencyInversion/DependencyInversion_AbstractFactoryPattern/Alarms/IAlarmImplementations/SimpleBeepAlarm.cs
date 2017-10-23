using System;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class SimpleBeepAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            Console.Beep();
        }
    }
}