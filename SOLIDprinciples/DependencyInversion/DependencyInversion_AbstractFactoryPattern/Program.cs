using DependencyInversion_AbstractFactoryPattern.Alarms;
using System.Collections.Generic;
using System.Diagnostics;

namespace DependencyInversion_AbstractFactoryPattern
{
    public static class Program
    {
        private static TemperatureSensor _temperatureSensor1;
        private static TemperatureSensor _temperatureSensor2;

        /// <summary>
        /// The abstract factory is responsible for creating objects of a common domain. Below, we use it to create visible and audible alarm for a collection of sensors.
        /// </summary>
        public static void Main()
        {
            _temperatureSensor1 = new TemperatureSensor("Temp1");
            _temperatureSensor2 = new TemperatureSensor("Temp2");

            IEnumerable<ISensor> sensorCollection = new List<ISensor>() {
                _temperatureSensor1,
                _temperatureSensor2 };

            // standard alarms
            AlarmFactory standardAlarmFactory = new StandardAlarmFactory();
            AttachAlarmsToSensors(standardAlarmFactory, sensorCollection); // executes the factory methods
            SensorCabinet sensorCabinet = new SensorCabinet(sensorCollection);
            sensorCabinet.TestAlarms();

            // enhanced alarms
            AlarmFactory enhancedAlarmFactory = new EnhancedAlarmFactory();
            AttachAlarmsToSensors(enhancedAlarmFactory, sensorCollection);  // executes the factory methods
            sensorCabinet = new SensorCabinet(sensorCollection);
            sensorCabinet.TestAlarms();
        }

        /// <summary>
        /// Executes the factory methods and thus creates the suitable alarm objects
        /// </summary>
        private static void AttachAlarmsToSensors(AlarmFactory alarmFactory, IEnumerable<ISensor> sensors)
        {
            Debug.Assert(sensors != null, "list of sensors should be initialized");

            foreach (ISensor sensor in sensors)
            {
                sensor.ClearAlarms();

                IAlarm visibleAlarm = alarmFactory.CreateVisibleAlarm();
                sensor.AttachAlarm(visibleAlarm);

                IAlarm audiobleAlarm = alarmFactory.CreateAudibleAlarm();
                sensor.AttachAlarm(audiobleAlarm);
            }
        }
    }
}