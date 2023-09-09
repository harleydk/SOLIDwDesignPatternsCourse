using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DependencyInversion;

namespace DependencyInversion_GoodDesign
{
    public sealed class SensorCabinet
    {
        private readonly IEnumerable<ISensor> _sensors;

        public SensorCabinet(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            _sensors = sensors;
        }

        public IEnumerable<TemperatureSensorData> GetAllTemperatureSensorsData()
        {
            IEnumerable<TemperatureSensor> temperatureSensors = _sensors.Where(sensor => sensor is TemperatureSensor).Cast<TemperatureSensor>();
            foreach (TemperatureSensor temperatureSensor in temperatureSensors)
            {
                TemperatureSensorData temperatureSensorData = GetTemperatureSensorData(temperatureSensor);
                yield return temperatureSensorData;
            };
        }

        private TemperatureSensorData GetTemperatureSensorData(TemperatureSensor temperatureSensor)
        {
            string sensorId = temperatureSensor.Id;
            double temperature = temperatureSensor.GetTemperature();

            Debug.Assert(!string.IsNullOrWhiteSpace(sensorId), "sensor-id should not be null or blank");
            Debug.Assert(temperature >= 0, "temperature should be >= 0");

            return new TemperatureSensorData(sensorId, temperature);
        }
    }
}