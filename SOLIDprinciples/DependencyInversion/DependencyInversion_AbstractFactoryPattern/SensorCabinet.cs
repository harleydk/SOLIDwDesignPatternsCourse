using System.Collections.Generic;
using System.Diagnostics;
using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class SensorCabinet
    {
        private readonly List<ISensor> _sensors;

        public SensorCabinet(List<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            _sensors = sensors;
        }

        public void TestAlarms()
        {
            _sensors.ForEach(alarm => alarm.RaiseAlarms());
        }
    }
}