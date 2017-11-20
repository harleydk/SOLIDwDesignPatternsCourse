using System.Collections.Generic;

namespace DependencyInversion_GoodDesign
{
    public static partial class Program
    {
        private static TemperatureSensor _temperatureSensor1;
        private static TemperatureSensor _temperatureSensor2;
        private static PressureSensor _pressureSensor;
        private static DisplayAlarm _displayAlarm;
        private static WarningBellAlarm _warningBellAlarm;
        private static TemperatureSensorLogger temperatureSensorLogger;

        /// <summary>
        /// The good design stipulates that we remove the logging-consideration from the SensorCabinet-class altogether. Breaks with the single responsibility principles, anyway.
        /// </summary>
        public static void Main()
        {
            // "Composition root"
            InitializaAlarms();
            InitializeSensors();
            AttachAlarmsToSensors();

            IEnumerable<ISensor> sensorCollection = new List<ISensor>() {
                _temperatureSensor1,
                _temperatureSensor2,
                _pressureSensor };
            SensorCabinet sensorCabinet = new SensorCabinet(sensorCollection);
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            // By removing the logger from the sensor-cabinet, we forego problems with the single-responsibility principle.
            InitializeTemperatureSensorLogger();
            var temperatureSensorData = sensorCabinet.GetAllTemperatureSensorsData();
            temperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(temperatureSensorData);

            //
        }

        private static void AttachAlarmsToSensors()
        {
            _temperatureSensor1.AttachAlarm(_displayAlarm);

            _temperatureSensor2.AttachAlarm(_displayAlarm);
            _temperatureSensor2.AttachAlarm(_warningBellAlarm);

            _pressureSensor.AttachAlarm(_displayAlarm);
            _pressureSensor.AttachAlarm(_warningBellAlarm);
        }

        private static void InitializeSensors()
        {
            _temperatureSensor1 = new TemperatureSensor("Temp1");

            _temperatureSensor2 = new TemperatureSensor("Temp2");
            _pressureSensor = new PressureSensor();
        }

        private static void InitializaAlarms()
        {
            _displayAlarm = new DisplayAlarm();
            _warningBellAlarm = new WarningBellAlarm();
        }

        private static void InitializeTemperatureSensorLogger()
        {
            DiagnosticsLogger diagnosticsLogger = new DiagnosticsLogger();
            temperatureSensorLogger = new TemperatureSensorLogger(diagnosticsLogger);
        }
    }
}