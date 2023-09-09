using System.Collections.Generic;

namespace DependencyInversion_BetterDesign
{
    public static class Program
    {
        private static TemperatureSensor _temperatureSensor1;
        private static TemperatureSensor _temperatureSensor2;
        private static PressureSensor _pressureSensor;
        private static DisplayAlarm _displayAlarm;
        private static WarningBellAlarm _warningBellAlarm;

        /// <summary>
        /// A better design is to give the SensorCabinet the sensors it needs, in its constructor.
        /// We're also using method injection to inject the logger needed for the WriteAllTemperatureSensorsDataToLog() method.
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
            SensorCabinet sensorCabinet = new(sensorCollection);
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            DiagnosticsLogger diagnosticsLogger = new();
            sensorCabinet.WriteAllTemperatureSensorsDataToLog(diagnosticsLogger); // 'method injection'

            // Assuming we can't yank the logging-responsibility out of the sensor-cabinet class, method injection will have to do.
            // Introduce fluid interface pattern towards this purpose.
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
    }
}