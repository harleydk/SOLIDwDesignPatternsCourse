namespace DependencyInversion_AbstractFactoryPattern
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);

        void ClearAlarms();

        void RaiseAlarms();
    }
}