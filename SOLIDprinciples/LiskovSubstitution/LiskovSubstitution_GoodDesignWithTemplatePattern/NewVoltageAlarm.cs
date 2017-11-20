namespace LiskovSubstitution_BadDesign
{
    public sealed class NewVoltageAlarm : VoltageAlarmBase
    {
        private const int NUMBER_OF_ALARM_REPETITIONS = 3;

        public NewVoltageAlarm(double alarmMinimumVoltageValue) : base(alarmMinimumVoltageValue)
        {
        }

        protected override int GetNumberOfAlarmRepetitions()
        {
            return NUMBER_OF_ALARM_REPETITIONS;
        }

        protected override double GetMaximumAllowableVoltageLevel()
        {
            return 5d; // 5v max
        }

        protected override bool ShouldResetNumberOfAlarmsRaised()
        {
            return true;
        }
    }
}