using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern.AlarmFactories
{
    public sealed class StandardAlarmFactory : IAlarmFactory
    {
        public IAlarm CreateAudibleAlarm()
        {
            return new WarningBellAlarm();
        }

        public IAlarm CreateVisibleAlarm()
        {
            return new DisplayAlarm();
        }
    }
}