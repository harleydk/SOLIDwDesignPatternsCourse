using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class StandardVoltageAlarm : IVoltageAlarm
    {
        public int NumberOfAlarmsRaised { get; private set; }

        public double VoltageAlarmThreshold { get; private set; }

        public StandardVoltageAlarm(double alarmVoltageThreshold)
        {
            NumberOfAlarmsRaised = 0;
            VoltageAlarmThreshold = alarmVoltageThreshold;
        }

        public bool HasVoltageDroppedBelowThreshold(double currentVoltageLevel)
        {
            bool hasVoltageDroppedBelowMinimum = currentVoltageLevel < VoltageAlarmThreshold;
            return hasVoltageDroppedBelowMinimum;
        }

        public void RaiseAlarm()
        {
            NumberOfAlarmsRaised += 1;
            Debug.WriteLine($"Alarm raised {NumberOfAlarmsRaised} times.");
        }
    }
}