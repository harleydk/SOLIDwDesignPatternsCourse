using System;
using System.Collections.Generic;

namespace InterfaceSegregation_AdapterPattern
{
    public sealed class CheapChineseSensorCabinetAdapter : ICabinetSensorEventing
    {
        private readonly CheapChineseSensorCabinetWithPreloadedSensors _cheapChineseSensorCabinet;

        public event EventHandler<SensorEventArgs> SensorEvent;

        public CheapChineseSensorCabinetAdapter(IEnumerable<ISensor> sensors)
        {
            _cheapChineseSensorCabinet = new CheapChineseSensorCabinetWithPreloadedSensors(sensors);

            _cheapChineseSensorCabinet.SensorEvent += _cheapChineseSensorCabinet_SensorEvent;
        }

        private void _cheapChineseSensorCabinet_SensorEvent(object sender, SensorEventArgs e)
        {
            this.FireSensorEvent(sender, e);
        }

        public void FireSensorEvent(object sender, SensorEventArgs e)
        {
            SensorEvent?.Invoke(this, e);
        }
    }
}