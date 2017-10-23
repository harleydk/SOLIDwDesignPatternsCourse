using Ninject.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion_GoodDesign
{
    public sealed class TemperatureSensorLogger
    {
        private ILogger _logger;

        public TemperatureSensorLogger(ILogger diagnosticsLogger)
        {
            _logger = diagnosticsLogger;
        }

        /// <summary>
        /// Write sensordata for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog(IEnumerable<(string, double)> temperatureSensorData)
        {
            temperatureSensorData.AsParallel().ForAll(sensorData =>
           {
               string logMessage = $"Sensor {sensorData.Item1} reported value {sensorData.Item2.ToString("N2")}";
               _logger.Info(logMessage);
           });
        }
    }
}