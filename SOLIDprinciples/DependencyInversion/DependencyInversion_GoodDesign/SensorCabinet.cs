using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public IEnumerable<(string SensorId, double Temperature)> GetAllTemperatureSensorsData()
        {
            IList<(string SensorId, double Temperature)> temperatureSensorDataList = new List<(string SensorId, double Temperature)>();

            IEnumerable<TemperatureSensor> temperaturesSensors = _sensors.Where(sensor => sensor is TemperatureSensor).Cast<TemperatureSensor>();
            temperaturesSensors.AsParallel().ForAll(temperatureSensor =>
            {
                var temperatureSensorData = GetTemperatureSensorData(temperatureSensor);
                temperatureSensorDataList.Add(temperatureSensorData);
            });

            return temperatureSensorDataList.AsEnumerable();
        }

        private (string SensorId, double Temperature) GetTemperatureSensorData(TemperatureSensor temperatureSensor)
        {
            string SensorId = temperatureSensor.Id;
            double Temperature = temperatureSensor.GetTemperature();

            Debug.Assert(!string.IsNullOrWhiteSpace(SensorId), "sensor-id should not be null or blank");
            Debug.Assert(Temperature >= 0, "temperature shouldbe >= 0");

            return (SensorId, Temperature);
        }
    }
}