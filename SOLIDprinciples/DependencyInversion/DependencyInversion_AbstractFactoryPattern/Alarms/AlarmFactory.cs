namespace DependencyInversion_AbstractFactoryPattern.Alarms
{
    /// <summary>
    /// Interface for creating an interface which creates alarms which share a common theme.
    /// </summary>
    public interface AlarmFactory
    {
        IAlarm CreateVisibleAlarm(); // "factory method"

        IAlarm CreateAudibleAlarm(); // "factory method"
    }
}