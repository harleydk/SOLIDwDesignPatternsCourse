using System.Collections.Generic;

namespace DependencyInversion_fluidInterfacePattern
{
    /// <summary>
    /// Demonstrates 'fluid interface pattern' aka “Method chaining” ;
    /// a common technique where each method returns an object and all these methods can be chained together to form a single statement.
    ///
    /// Can make for more readable code - but be wary of nulls, and thus consider the null-object pattern.
    /// </summary>
    public static partial class Program
    {
        private static TemperatureSensor _temperatureSensor1;
        private static TemperatureSensor _temperatureSensor2;
        private static PressureSensor _pressureSensor;
        private static DisplayAlarm _displayAlarm;
        private static WarningBellAlarm _warningBellAlarm;
        private static TemperatureSensorLogger temperatureSensorLogger;

        public static void Main()
        {
            // "Composition root"
            InitializaAlarms();
            InitializeSensors();
            AttachAlarmsToSensors();
            InitializeSensorLoggers();

            List<ISensor> sensorCollection = new List<ISensor>() {
                _temperatureSensor1,
                _temperatureSensor2,
                _pressureSensor };

            // Note the 'accidental' call to the WithPressureSensorLogger, that we actually never use.
            // As we don't need it, we should not call it - but we've made sure to initialize it to a null-object variant in the sensor-cabinet.cs class, just in case.
            SensorCabinet sensorCabinet = new SensorCabinet(sensorCollection).
                WithTemperatureSensorLogger(temperatureSensorLogger).
                WithPressureSensorLogger(); // junior programmer wrote this line, but forgot that it's never used - are we guarded against that... Yes, we are.
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            sensorCabinet.WriteAllTemperatureSensorsDataToLog();
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

        private static void InitializeSensorLoggers()
        {
            DiagnosticsLogger diagnosticsLogger = new DiagnosticsLogger();
            temperatureSensorLogger = new TemperatureSensorLogger(diagnosticsLogger);
        }
    }
}