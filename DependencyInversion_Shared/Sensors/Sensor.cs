using System.Collections.Generic;

namespace DependencyInversion
{
    public class Sensor : ISensor
    {
        protected List<IAlarm> _sensorAlarms = new();

        public void AttachAlarm(IAlarm sensorAlarm)
        {
            _sensorAlarms.Add(sensorAlarm);
        }

        public void RaiseAlarms()
        {
            _sensorAlarms.ForEach(alarm => alarm.RaiseAlarm());
        }
    }
}