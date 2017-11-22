namespace LiskovSubstitution_GoodDesign
{
    public interface IVoltageAlarm
    {
        int NumberOfAlarmsRaised { get; }

        double VoltageAlarmThreshold { get; }

        bool HasVoltageDroppedBelowThreshold(double voltageLevel);

        void RaiseAlarm();
    }
}