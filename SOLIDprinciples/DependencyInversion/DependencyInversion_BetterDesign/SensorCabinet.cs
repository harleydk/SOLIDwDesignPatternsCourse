using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_BetterDesign
{
    public sealed class SensorCabinet
    {
        public IEnumerable<ISensor> Sensors { get; private set; }
     
        public SensorCabinet(IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized at this point");
            Sensors = sensors;
        }

        /// <summary>
        /// Write sensordata for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog(DiagnosticsLogger diagnosticsLogger) // -- target for method injection - but how do we feel about that...?
        {
            IEnumerable<TemperatureSensor> temperaturesSensors = Sensors.Where(sensor => sensor is TemperatureSensor).Cast<TemperatureSensor>();
            temperaturesSensors.AsParallel().ForAll(temperatureSensor =>
            {
                string logMessage = $"Sensor {temperatureSensor.Id} reported value {temperatureSensor.GetTemperature().ToString("N2")}";
                diagnosticsLogger.WriteToLog(logMessage);
            });
        }
    }
}