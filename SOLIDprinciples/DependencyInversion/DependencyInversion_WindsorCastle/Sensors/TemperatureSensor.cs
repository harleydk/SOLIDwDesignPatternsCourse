using System;

namespace DependencyInversion_WindsorCastle
{
    public sealed class TemperatureSensor : ISensor
    {
        private IAlarm _sensorAlarm;
        public string Id { get; private set; }

        public TemperatureSensor(string sensorId)
        {
            Id = sensorId;
        }

        public void AttachAlarm(IAlarm alarm)
        {
            _sensorAlarm = alarm;
        }

        public double GetTemperature()
        {
            // Let's pretend we're physically hooked up to a sensor, and that this method will return its current temperature.
            Random rnd = new Random();
            return rnd.NextDouble();
        }
    }
}