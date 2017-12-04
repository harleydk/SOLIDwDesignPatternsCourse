namespace DependencyInversion_WindsorCastle
{
    public sealed class PressureSensor : ISensor
    {
        private IAlarm _sensorAlarm;

        public IAlarm Alarm
        {
            get { return _sensorAlarm; }
        }

        public PressureSensor(IAlarm sensorAlarm)
        {
            _sensorAlarm = sensorAlarm;
        }

    }
}