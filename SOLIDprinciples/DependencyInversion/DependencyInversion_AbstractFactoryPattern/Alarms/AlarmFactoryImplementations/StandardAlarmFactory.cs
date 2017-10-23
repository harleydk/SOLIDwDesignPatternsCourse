namespace DependencyInversion_AbstractFactoryPattern.Alarms
{
    public sealed class StandardAlarmFactory : AlarmFactory
    {
        public IAlarm CreateAudibleAlarm()
        {
            return new SimpleBeepAlarm();
        }

        public IAlarm CreateVisibleAlarm()
        {
            return new DisplayAlarm();
        }
    }
}