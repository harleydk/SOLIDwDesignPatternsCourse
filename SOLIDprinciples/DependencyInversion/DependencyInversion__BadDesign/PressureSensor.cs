namespace DependencyInversion_BadDesign
{
    public sealed class PressureSensor : ISensor
    {
        private IAlarm _sensorAlarm;

        public void AttachAlarm(IAlarm sensorAlarm)
        {
            _sensorAlarm = sensorAlarm;
        }
    }
}