using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern.AlarmFactories
{
    public sealed class StandardSpellsAlarmFactory : ISpellAlarmFactory
    {
        public ISpellAlarm CreateAudibleAlarm()
        {
            return new WarningBellAlarm();
        }

        public ISpellAlarm CreateVisibleAlarm()
        {
            return new DisplayAlarm();
        }
    }
}