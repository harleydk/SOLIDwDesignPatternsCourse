using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    // To ensure compatibility among sub-classes, we can introduce an abstract base-class that allows for corresponding behaviour throughout our subclassings. I.e. this base-class compiles the combined functionality of the various IVoltageAlarm implementations we have (so far).
    //? Note the use of the template-pattern, to achieve compatability.
    public abstract class VoltageAlarmBase : IVoltageAlarm
    {
        private const int DEFAULT_NUMBER_OF_ALARM_ITERATIONS = 1;
        private const double DEFAULT_MAX_ALLOWED_VOLTAGE_LEVEL = double.MaxValue;
        private const bool DEFAULT_SHOULD_RESET_NUMBER_OF_ALARMS = false;

        public int NumberOfAlarmsRaised { get; private set; }

        public double VoltageAlarmThreshold { get; private set; }

        public VoltageAlarmBase(double alarmVoltageThreshold)
        {
            NumberOfAlarmsRaised = 0;
            VoltageAlarmThreshold = alarmVoltageThreshold;
        }

        public bool HasVoltageDroppedBelowThreshold(double currentVoltageLevel) // 'Template method'
        {
            // The NewVoltageAlarm requires a max voltage of 5, but our StandardVoltageAlarm doesn't have this requirement. We can again use the template pattern to accomodate, defaulting to double.maxvalue.
            double maximumAllowableVoltageLevel = GetMaximumAllowableVoltageLevel();
            Debug.Assert(currentVoltageLevel < maximumAllowableVoltageLevel);

            bool hasVoltageDroppedBelowThreshold = currentVoltageLevel < VoltageAlarmThreshold;
            return hasVoltageDroppedBelowThreshold;
        }

        protected virtual double GetMaximumAllowableVoltageLevel()
        {
            return DEFAULT_MAX_ALLOWED_VOLTAGE_LEVEL;
        }

        public void RaiseAlarm() // 'Template method'. Note we adopted the NewVoltageAlarm's repetition-scheme here, but defaults it to '1' to accomodate the StandardVoltageAlarm.
        {
            int numberOfAlarmRepetitions = GetNumberOfAlarmRepetitions();
            for (int i = 0; i < numberOfAlarmRepetitions; i++)
            {
                NumberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {NumberOfAlarmsRaised} times.");
            }

            if (ShouldResetNumberOfAlarmsRaised())
            {
                ResetNumberOfAlarmsRaised();
            }
        }

        protected virtual bool ShouldResetNumberOfAlarmsRaised() // 'Hook' method
        {
            return DEFAULT_SHOULD_RESET_NUMBER_OF_ALARMS;
        }

        protected virtual int GetNumberOfAlarmRepetitions()
        {
            return DEFAULT_NUMBER_OF_ALARM_ITERATIONS;
        }

        private void ResetNumberOfAlarmsRaised()
        {
            NumberOfAlarmsRaised = 0;
        }
    }
}