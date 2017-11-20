namespace DependencyInversion_BadDesign
{
    public sealed class SensorCabinet
    {
        // this breaks with what principle...?
        private TemperatureSensor _temperatureSensor1;

        private TemperatureSensor _temperatureSensor2;
        private PressureSensor _pressureSensor;
        private DisplayAlarm _displayAlarm;
        private WarningBellAlarm _warningBellAlarm;

        private DiagnosticsLogger diagnosticsLogger;

        public SensorCabinet()
        {
            InitializaAlarms();
            InitializeSensors();
            AttachAlarmsToSensors();
        }

        private void AttachAlarmsToSensors()
        {
            _temperatureSensor1.AttachAlarm(_displayAlarm);

            _temperatureSensor2.AttachAlarm(_displayAlarm);
            _temperatureSensor2.AttachAlarm(_warningBellAlarm);

            _pressureSensor.AttachAlarm(_displayAlarm);
            _pressureSensor.AttachAlarm(_warningBellAlarm);
        }

        private void InitializeSensors()
        {
            _temperatureSensor1 = new TemperatureSensor("Temp1");
            _temperatureSensor2 = new TemperatureSensor("Temp2");
            _pressureSensor = new PressureSensor();
        }

        private void InitializaAlarms()
        {
            _displayAlarm = new DisplayAlarm();
            _warningBellAlarm = new WarningBellAlarm();
        }

        public void AttachLogger()
        {
            diagnosticsLogger = new DiagnosticsLogger();
        }

        /// <summary>
        /// Write sensordata for all temperature-sensors to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSensorsDataToLog()
        {
            double temperatureSensorValue1 = _temperatureSensor1.GetTemperature();
            diagnosticsLogger.WriteToLog($"Sensor {_temperatureSensor1.Id} reported value {temperatureSensorValue1.ToString("N2")}");
            double temperatureSensorValue2 = _temperatureSensor2.GetTemperature();
            diagnosticsLogger.WriteToLog($"Sensor {_temperatureSensor2.Id} reported value {temperatureSensorValue2.ToString("N2")}");
        }
    }
}