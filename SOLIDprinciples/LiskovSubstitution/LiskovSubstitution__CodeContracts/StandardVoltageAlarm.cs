namespace LiskovSubstitution_CodeContracts
{
    public sealed class StandardVoltageAlarm : VoltageAlarmBase
    {
        public StandardVoltageAlarm(double alarmVoltageThreshold) : base(alarmVoltageThreshold)
        {
        }
    }
}