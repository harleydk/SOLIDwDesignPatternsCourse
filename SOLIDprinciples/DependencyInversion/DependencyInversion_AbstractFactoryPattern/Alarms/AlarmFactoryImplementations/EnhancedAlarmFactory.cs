namespace DependencyInversion_AbstractFactoryPattern.Alarms
{
    public sealed class EnhancedAlarmFactory : AlarmFactory
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