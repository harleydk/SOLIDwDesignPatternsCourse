namespace DependencyInversion_WindsorCastle
{
    public sealed class PressureSensor : ISensor
    {
        private IAlarm _sensorAlarm;

        public PressureSensor(IAlarm sensorAlarm)
        {
            _sensorAlarm = sensorAlarm;
        }

        public void AttachAlarm(IAlarm sensorAlarm)
        {
            _sensorAlarm = sensorAlarm;
        }
    }
}