using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern.AlarmFactories
{
    public sealed class EnhancedSpellsAlarmFactory : ISpellAlarmFactory
    {
        public ISpellAlarm CreateAudibleAlarm()
        {
            return new PersistentBeepAlarm();
        }

        public ISpellAlarm CreateVisibleAlarm()
        {
            return new EnhancedDisplayAlarm();
        }
    }
}