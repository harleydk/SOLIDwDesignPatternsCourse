using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterfaceSegregation_AdapterPattern
{
    /// <summary>
    /// Third-party code, can't be modified. Sadly adheres to the old ISensorCabinet industry-standard interface:
    /// We need an adapter for this.
    /// </summary>
    public sealed class CheapChineseSensorCabinetWithPreloadedSensors : ISensorCabinet
    {
        private readonly IEnumerable<ISensor> _preloadedSensors;

        public IList<ISensor> Sensors => throw new NotImplementedException();

        public event EventHandler<SensorEventArgs> SensorEvent;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public CheapChineseSensorCabinetWithPreloadedSensors(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "collection of sensors should be initialized.");
            Debug.Assert(sensors.Any(), "collection of sensors must not be empty");

            _preloadedSensors = sensors;
        }

        public void FireSensorEvent(object sender, SensorEventArgs e)
        {
            SensorEvent?.Invoke(this, e);
        }

        public void AddSensor(ISensor sensor)
        {
            throw new NotImplementedException();
        }

        public void RaiseCabinetOpenAlarm()
        {
            throw new NotImplementedException();
        }

        public void FireCabinetOpenedEvent(object sender, CabinetOpenedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ResetCabinetOpenAlarm()
        {
            throw new NotImplementedException();
        }

        public string GetCabinetLastOpenedByUserId()
        {
            throw new NotImplementedException();
        }
    }
}