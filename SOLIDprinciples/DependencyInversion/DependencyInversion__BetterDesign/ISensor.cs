namespace DependencyInversion_BetterDesign
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}