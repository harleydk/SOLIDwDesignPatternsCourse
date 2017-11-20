namespace DependencyInversion_fluidInterfacePattern
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}