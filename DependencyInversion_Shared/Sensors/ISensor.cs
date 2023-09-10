namespace DependencyInversion
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);

        void RaiseAlarms();
    }

}