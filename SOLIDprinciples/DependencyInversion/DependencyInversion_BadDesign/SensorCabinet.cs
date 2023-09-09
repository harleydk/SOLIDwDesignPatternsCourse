using DependencyInversion;
using System.Collections.Generic;

namespace DependencyInversion_BadDesign
{
    /// <summary>
    /// A sensor cabinet, that holds a number of sensors.
    /// </summary>
    /// <remarks>
    /// This class does not honor the dependency inversion principle - lots of hard-wired dependencies.
    /// </remarks>
    public sealed class SensorCabinet
    {
        public TemperatureSensor TemperatureSensor1 { get; private set; }
        public TemperatureSensor TemperatureSensor2 { get; private set; }
        public PressureSensor PressureSensor { get; private set; }
        public DisplayAlarm DisplayAlarm { get; private set; }
        public WarningBellAlarm WarningBellAlarm { get; private set; }

        public TemperatureSensorLogger TemperatureSensorLogger { get; private set; }

        public void InitializeSensors()
        {
            TemperatureSensor1 = new TemperatureSensor(sensorId: "Temp1");
            TemperatureSensor2 = new TemperatureSensor(sensorId: "Temp2");
            PressureSensor = new PressureSensor();
        }

        public void InitializeAlarms()
        {
            DisplayAlarm = new DisplayAlarm();
            WarningBellAlarm = new WarningBellAlarm();
        }

        public void AttachAlarmsToSensors()
        {
            TemperatureSensor1.AttachAlarm(DisplayAlarm);

            TemperatureSensor2.AttachAlarm(DisplayAlarm);
            TemperatureSensor2.AttachAlarm(WarningBellAlarm);

            PressureSensor.AttachAlarm(DisplayAlarm);
            PressureSensor.AttachAlarm(WarningBellAlarm);
        }

        public void AttachLogger()
        {
            TemperatureSensorLogger = new TemperatureSensorLogger(new DiagnosticsLogger());
        }

        /// <summary>
        /// Write sensor data for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog()
        {
            TemperatureSensorData sensorData1 = new(SensorId: TemperatureSensor1.Id, TemperatureSensor1.GetTemperature());
            TemperatureSensorData sensorData2 = new(SensorId: TemperatureSensor2.Id, TemperatureSensor2.GetTemperature());
            TemperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(new List<TemperatureSensorData> { sensorData1, sensorData2 });
        }
    }
}