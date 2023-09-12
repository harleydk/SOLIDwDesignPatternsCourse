using System.Collections.Generic;

namespace DependencyInversion
{
    /// <summary>
    /// A logger that writes temperature sensor data.
    /// </summary>
    public sealed class TemperatureSensorLogger
    {
        private readonly DiagnosticsLogger _diagnosticsLogger;

        public TemperatureSensorLogger(DiagnosticsLogger diagnosticsLogger)
        {
            _diagnosticsLogger = diagnosticsLogger;
        }

        /// <summary>
        /// Write sensor data for all temperature-sensors.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog(IEnumerable<TemperatureSensorData> temperatureSensorDataList)
        {
            foreach(TemperatureSensorData temperatureSensorData in temperatureSensorDataList)
            {
                string logMessage = $"Sensor {temperatureSensorData.SensorId} reported value {temperatureSensorData.Temperature:N2}";
                _diagnosticsLogger.WriteToLog(logMessage);
            }
        }
    }
}