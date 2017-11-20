namespace DependencyInversion_GoodDesign
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