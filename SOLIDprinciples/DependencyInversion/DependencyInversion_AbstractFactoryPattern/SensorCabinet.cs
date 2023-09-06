using System.Collections.Generic;
using System.Diagnostics;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class SensorCabinet
    {
        private readonly IEnumerable<ISensor> _sensors;

        public SensorCabinet(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            _sensors = sensors;
        }

        public void TestAlarms()
        {
            foreach (ISensor sensor in _sensors)
                sensor.RaiseAlarms();
        }
    }
}