namespace LiskovSubstitution_GoodDesign
{
    public sealed class StandardVoltageAlarm : VoltageAlarmBase
    {
        public StandardVoltageAlarm(double alarmVoltageThreshold) : base(alarmVoltageThreshold)
        {
        }
    }
}