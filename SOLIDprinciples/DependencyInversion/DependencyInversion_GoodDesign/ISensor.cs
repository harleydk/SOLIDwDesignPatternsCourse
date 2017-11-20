namespace DependencyInversion_GoodDesign
{
    public interface ISensor
    {
        void AttachAlarm(IAlarm sensorAlarm);
    }
}