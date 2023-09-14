using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern.AlarmFactories
{
    /// <summary>
    /// Interface for creating an interface which creates objects - alarms, in this example - which 
    /// share a common theme.
    /// </summary>
    public interface ISpellAlarmFactory
    {
        ISpellAlarm CreateVisibleAlarm();

        ISpellAlarm CreateAudibleAlarm();
    }
}