using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class TemperatureSensor : ISensor
    {
        private IList<IAlarm> _sensorAlarms;
        public string Id { get; private set; }

        public TemperatureSensor(string sensorId)
        {
            Id = sensorId;
        }

        public void AttachAlarm(IAlarm alarm)
        {
            if (_sensorAlarms == null)
                _sensorAlarms = new List<IAlarm>();

            _sensorAlarms.Add(alarm);
            Debug.Assert(_sensorAlarms.Count > 0, "just attached an alarm - collection-count should be > 0");
        }

        public void ClearAlarms()
        {
            if (_sensorAlarms != null)
                _sensorAlarms.Clear();
        }

        public void RaiseAlarms()
        {
            _sensorAlarms.AsParallel().ForAll(sensorAlarm => sensorAlarm.RaiseAlarm());
        }

        public double GetTemperature()
        {
            // Let's pretend we're physically hooked up to a sensor, and that this method will return its current temperature.
            Random rnd = new Random();
            return rnd.NextDouble();
        }
    }
}