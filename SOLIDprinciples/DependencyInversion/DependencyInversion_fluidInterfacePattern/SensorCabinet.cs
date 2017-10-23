using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class SensorCabinet
    {
        private IList<ISensor> _sensors;
        private TemperatureSensorLogger _temperatureSensorLogger;
        private PressureSensorLogger _pressureSensorLogger;

        public SensorCabinet(IList<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            _sensors = sensors;

            // initialize loggers with default null-object implementations
            _temperatureSensorLogger = new TemperatureSensorNullObjectLogger();
            _pressureSensorLogger = new PressureSensorNullObjectLogger();
        }

        public SensorCabinet WithTemperatureSensorLogger(TemperatureSensorLogger temperatureSensorLogger = null)
        {
            if (temperatureSensorLogger != null)
                _temperatureSensorLogger = temperatureSensorLogger;

            return this;
        }

        public SensorCabinet WithPressureSensorLogger(PressureSensorLogger pressureSensorLogger = null)
        {
            if (pressureSensorLogger != null)
                _pressureSensorLogger = pressureSensorLogger;

            return this;
        }

        /// <summary>
        /// Write sensordata for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog()
        {
            var allTemparatureSensorsData = GetAllTemperatureSensorsData();
            _temperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(allTemparatureSensorsData);
        }

        private IList<(string SensorId, double Temperature)> GetAllTemperatureSensorsData()
        {
            IList<(string SensorId, double Temperature)> temperatureSensorDataList = new List<(string SensorId, double Temperature)>();

            IEnumerable<TemperatureSensor> temperaturesSensors = _sensors.Where(sensor => sensor is TemperatureSensor).Cast<TemperatureSensor>();
            temperaturesSensors.AsParallel().ForAll(temperatureSensor =>
            {
                var temperatureSensorData = GetTemperatureSensorData(temperatureSensor);
                temperatureSensorDataList.Add(temperatureSensorData);
            });

            return temperatureSensorDataList;
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