namespace LiskovSubstitution_BadDesign
{
    public sealed class StandardVoltageAlarm : VoltageAlarmBase
    {
        public StandardVoltageAlarm(double alarmVoltageThreshold) : base(alarmVoltageThreshold)
        {
        }
    }
}