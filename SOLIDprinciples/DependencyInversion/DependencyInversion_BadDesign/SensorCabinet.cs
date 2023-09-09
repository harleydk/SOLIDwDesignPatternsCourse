namespace DependencyInversion_BadDesign
{
    public sealed class SensorCabinet
    {
        public TemperatureSensor TemperatureSensor1 { get; private set; }
        public TemperatureSensor TemperatureSensor2 { get; private set; }
        public PressureSensor PressureSensor { get; private set; }
        public DisplayAlarm DisplayAlarm { get; private set; }
        public WarningBellAlarm WarningBellAlarm { get; private set; }

        public DiagnosticsLogger DiagnosticsLogger { get; private set; }

        public SensorCabinet()
        {
            // Lots of initializations within these methods.
            InitializeAlarms();
            InitializeSensors();
            AttachAlarmsToSensors();
        }

        private void AttachAlarmsToSensors()
        {
            TemperatureSensor1.AttachAlarm(DisplayAlarm);

            TemperatureSensor2.AttachAlarm(DisplayAlarm);
            TemperatureSensor2.AttachAlarm(WarningBellAlarm);

            PressureSensor.AttachAlarm(DisplayAlarm);
            PressureSensor.AttachAlarm(WarningBellAlarm);
        }

        private void InitializeSensors()
        {
            TemperatureSensor1 = new TemperatureSensor(sensorId: "Temp1");
            TemperatureSensor2 = new TemperatureSensor(sensorId: "Temp2");
            PressureSensor = new PressureSensor();
        }

        private void InitializeAlarms()
        {
            DisplayAlarm = new DisplayAlarm();
            WarningBellAlarm = new WarningBellAlarm();
        }

        public void AttachLogger()
        {
            DiagnosticsLogger = new DiagnosticsLogger();
        }

        /// <summary>
        /// Write sensor data for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog()
        {
            double temperatureSensorValue1 = TemperatureSensor1.GetTemperature();
            DiagnosticsLogger.WriteToLog($"Sensor {TemperatureSensor1.Id} reported value {temperatureSensorValue1:N2}");
            double temperatureSensorValue2 = TemperatureSensor2.GetTemperature();
            DiagnosticsLogger.WriteToLog($"Sensor {TemperatureSensor2.Id} reported value {temperatureSensorValue2:N2}");
        }
    }
}