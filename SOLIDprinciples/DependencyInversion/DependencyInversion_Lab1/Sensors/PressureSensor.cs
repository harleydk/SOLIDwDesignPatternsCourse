namespace DependencyInversion_Lab1
{
    public class PressureSensor : ISensor
    {
        private IAlarm _sensorAlarm;

        public void AttachAlarm(IAlarm sensorAlarm)
        {
            _sensorAlarm = sensorAlarm;
        }
    }
}