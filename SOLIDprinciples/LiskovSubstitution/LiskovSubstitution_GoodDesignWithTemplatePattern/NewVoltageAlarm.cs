namespace LiskovSubstitution_GoodDesign

{
    public sealed class NewVoltageAlarm : VoltageAlarmBase
    {
        private const int NUMBER_OF_ALARM_REPETITIONS = 3;

        public NewVoltageAlarm(double alarmMinimumVoltageValue) : base(alarmMinimumVoltageValue)
        {
        }

        public override int GetNumberOfAlarmRepetitions()
        {
            return NUMBER_OF_ALARM_REPETITIONS;
        }

        public override double GetMaximumAllowableVoltageLevel()
        {
            return 5d; // 5v max
        }
           
    }
}