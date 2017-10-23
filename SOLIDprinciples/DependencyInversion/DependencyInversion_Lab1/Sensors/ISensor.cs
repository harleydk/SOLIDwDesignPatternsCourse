namespace DependencyInversion_Lab1
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}