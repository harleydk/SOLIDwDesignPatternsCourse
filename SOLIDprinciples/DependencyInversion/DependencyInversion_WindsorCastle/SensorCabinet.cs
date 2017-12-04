using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_WindsorCastle
{
    public sealed class SensorCabinet
    {
        private IEnumerable<ISensor> _sensors;

        public SensorCabinet(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            _sensors = sensors;
        }

        public IEnumerable<IAlarm> GetAllSensorAlarms()
        {
            IList<IAlarm> sensorsAlarms = new List<IAlarm>();

            foreach (ISensor sensor in _sensors)
            {
                sensorsAlarms.Add(sensor.Alarm);
            }
        
            return sensorsAlarms.AsEnumerable();
        }
        
    }
}