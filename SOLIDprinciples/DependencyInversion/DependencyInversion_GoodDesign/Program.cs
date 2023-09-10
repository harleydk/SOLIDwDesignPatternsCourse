using DependencyInversion_GoodDesign.Configuration;
using DependencyInversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_GoodDesign
{
    public static partial class Program
    {
        /// <summary>
        /// The good design stipulates that ...
        /// ... primarily, we do our creation logic in the composition root, preferably from configuration - if possible.
        /// ... secondary, we also remove the logging-consideration from the SensorCabinet-class altogether. Besides breaking the 
        /// dependency inversion principle, we can easily identify this as a tendency to break with the single responsibility principles.
        /// </summary>
        /// <remarks>
        /// Here, the 'main' method is our so-called 'composition root', i.e. the entry-point into the application and 
        /// thus the suitable place for all the dependencies to be created. 
        /// </remarks>
        public static void Main(string[] args)
        {
            // Let's get the sensors from configuration. We could new them up, of course, if they don't lend themselves easily to configuration.
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile(@"sensorsAndAlarms.json").Build();
            List<SensorConfiguration> sensorsConfiguration = new();
            config.Bind("Sensors", sensorsConfiguration);
            Debug.Assert(sensorsConfiguration.Any(), "No sensors initialized from config");

            // Initialize the sensors based on their configuration data, and add them to the sensor-cabinet.
            IEnumerable<ISensor> sensorCollection = InitializeSensors(sensorsConfiguration);
            SensorCabinet sensorCabinet = new(sensorCollection);

            // At some point, we wish to write temperature sensor values to a log.
            // By removing the logger from the sensor-cabinet, we forego problems with the single-responsibility principle.
            IEnumerable<TemperatureSensorData> temperatureSensorData = sensorCabinet.GetAllTemperatureSensorsData();

            TemperatureSensorLogger temperatureSensorLogger = InitializeTemperatureSensorLogger();
            temperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(temperatureSensorData);
        }

        private static IEnumerable<ISensor> InitializeSensors(List<SensorConfiguration> sensorConfigurations)
        {
            foreach (SensorConfiguration sensorConfig in sensorConfigurations)
            {
                // Initialize sensor
                ISensor sensor = sensorConfig.SensorType switch
                {
                    SensorType.TemperatureSensor => new TemperatureSensor(sensorConfig.SensorId),
                    SensorType.PressureSensor => new PressureSensor(),
                    _ => throw new ArgumentException($"Invalid {nameof(SensorType)} {sensorConfig.SensorType}")
                };

                // attach alarms
                foreach (AlarmConfiguration alarmConfig in sensorConfig.Alarms)
                {
                    IAlarm alarm = InitializeAlarm(alarmConfig);
                    sensor.AttachAlarm(alarm);
                }

                yield return sensor;
            }
        }

        private static IAlarm InitializeAlarm(AlarmConfiguration alarmConfig)
        {
            IAlarm alarm = alarmConfig.AlarmType switch
            {
                AlarmType.DisplayAlarm => new DisplayAlarm(),
                AlarmType.WarningBellAlarm => new WarningBellAlarm(),
                _ => throw new ArgumentException($"No {nameof(AlarmType)} '{alarmConfig.AlarmType}'")
            };
            return alarm;
        }

        private static TemperatureSensorLogger InitializeTemperatureSensorLogger()
        {
            DiagnosticsLogger diagnosticsLogger = new();
            TemperatureSensorLogger temperatureSensorLogger = new(diagnosticsLogger);
            return temperatureSensorLogger;
        }
    }
}