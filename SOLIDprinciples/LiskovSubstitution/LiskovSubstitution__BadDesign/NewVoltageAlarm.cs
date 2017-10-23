using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class NewVoltageAlarm : IVoltageAlarm
    {
        private const int NUMBER_OF_ALARM_REPETITIONS = 3;
        public int NumberOfAlarmsRaised { get; private set; }

        public double VoltageAlarmThreshold { get; private set; }

        public NewVoltageAlarm(double voltageAlarmThreshold)
        {
            NumberOfAlarmsRaised = 0;
            VoltageAlarmThreshold = voltageAlarmThreshold;
        }

        public bool HasVoltageDroppedBelowThreshold(double currentVoltageLevel)
        {
            // violation - strenghed pre-condition!!
            Debug.Assert(currentVoltageLevel < 5); // our new sensor can only take as much...

            bool hasVoltageDroppedBelowMinimum = currentVoltageLevel < VoltageAlarmThreshold;
            return hasVoltageDroppedBelowMinimum;
        }

        public void RaiseAlarm()
        {
            // violation - difference in the meaningfullness of the function's implementation. StandardVoltageAlarm doesn't deal in repititions.
            for (int i = 0; i < NUMBER_OF_ALARM_REPETITIONS; i++)
            {
                NumberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {NumberOfAlarmsRaised} times.");
            }
        }

        public void ResetNumberOfAlarmsRaised()
        {
            NumberOfAlarmsRaised = 0;
        }
    }
}