using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class SensorCabinetWithPreloadedSensors : ICabinetSensorEventing
    {
        private readonly IEnumerable<ISensor> _preloadedSensors;

        public event EventHandler<SensorEventArgs> SensorEvent;

        public SensorCabinetWithPreloadedSensors(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "collection of sensors should be initialized.");
            Debug.Assert(sensors.Any(), "collection of sensors must not be empty");

            _preloadedSensors = sensors;
        }

        public void FireSensorEvent(object sender, SensorEventArgs e)
        {
            SensorEvent?.Invoke(this, e);
        }
    }
}