using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DependencyInversion;

namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class SensorCabinet
    {
        private List<ISensor> _sensors = new ();

        public SensorCabinet WithSensor(ISensor sensor)
        {
            _sensors.Add(sensor);
            return this;
        }

        /// <summary>
        /// Write sensor data for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog(DiagnosticsLogger diagnosticsLogger)
        {
            foreach (var sensor in _sensors.Where(sensor => sensor is TemperatureSensor).Cast<TemperatureSensor>())
            {
                TemperatureSensorData temperatureSensorData = GetTemperatureSensorData(sensor);
                diagnosticsLogger.WriteToLog(temperatureSensorData.ToString());
            }
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