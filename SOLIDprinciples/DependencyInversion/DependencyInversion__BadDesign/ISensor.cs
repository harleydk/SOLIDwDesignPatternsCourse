namespace DependencyInversion_BadDesign
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}