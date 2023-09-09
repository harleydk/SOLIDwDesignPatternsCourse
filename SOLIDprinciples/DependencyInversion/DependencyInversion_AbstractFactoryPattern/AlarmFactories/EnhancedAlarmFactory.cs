using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern.AlarmFactories
{
    public sealed class EnhancedAlarmFactory : IAlarmFactory
    {
        public IAlarm CreateAudibleAlarm()
        {
            return new PersistentBeepAlarm();
        }

        public IAlarm CreateVisibleAlarm()
        {
            return new EnhancedDisplayAlarm();
        }
    }
}