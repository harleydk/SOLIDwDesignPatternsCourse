namespace DependencyInversion_WindsorCastle
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}