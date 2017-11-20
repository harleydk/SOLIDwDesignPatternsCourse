using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_fluidInterfacePattern
{
    public class PressureSensorLogger
    {
        private DiagnosticsLogger _diagnosticsLogger;

        public PressureSensorLogger(DiagnosticsLogger diagnosticsLogger)
        {
            _diagnosticsLogger = diagnosticsLogger;
        }

        /// <summary>
        /// Write sensordata for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAveragePressureToLog(IList<double> temperatureSensorData)
        {
            Debug.Assert(temperatureSensorData != null, "temperatureSensorData should be initialized");
            Debug.Assert(temperatureSensorData.Count() > 0, "temperatureSensordata should not be an empty list");

            double combinedPressure = temperatureSensorData.Sum();
            string logMessage = $"Pressure at {combinedPressure / temperatureSensorData.Count()}";
            _diagnosticsLogger.WriteToLog(logMessage);
        }
    }
}