using DependencyInversion;
using DependencyInversion_AbstractFactoryPattern.AlarmFactories;
using System.Collections.Generic;
using System.Diagnostics;

namespace DependencyInversion_AbstractFactoryPattern
{
    /// <summary>
    /// 
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The abstract factory is responsible for creating objects of a common domain. Below, as an example, we use it 
        /// to create visible and audible alarm for a collection of sensors.
        /// </summary>
        /// <remarks>
        /// Abstract factories de-couple the creation-logic. Very useful for supporting multiple platforms, for example, or
        /// situation where we need to defer the creation based on run-time conditions we won't know about until, well, run-time.
        /// 
        /// Also good for database-connectivity, API clients and such, i.e. for initiating resources that appear complex or with 
        /// big initialization cost.
        /// 
        /// Furthermore, they are good for abstracting away logic that may undergo modification later in the development process.
        /// For example, with an abstract factory we can allow one type of consumer more resources than another, by offering one a 
        /// different factory-creator than the other.
        /// </remarks>
        public static void Main()
        {
            // A collection of sensors must have alarms attached to them:
            TemperatureSensor temperatureSensor1 = new TemperatureSensor("Temp1");
            TemperatureSensor temperatureSensor2 = new TemperatureSensor("Temp2");
            List<ISensor> sensorCollection = new() { temperatureSensor1, temperatureSensor2 };

            // For standard alarms, we use a standard alarm factory:
            IAlarmFactory standardAlarmFactory = new StandardAlarmFactory();
            sensorCollection.ForEach(sensor =>
            {
                sensor.AttachAlarm(standardAlarmFactory.CreateVisibleAlarm());
                sensor.AttachAlarm(standardAlarmFactory.CreateAudibleAlarm());
            });
            SensorCabinet sensorCabinet = new(sensorCollection);
            sensorCabinet.TestAlarms();

            // But for other scenarios, we might create 'enhanced' alarms via a different factory implementation:
            IAlarmFactory enhancedAlarmFactory = new EnhancedAlarmFactory();
            sensorCollection.ForEach(sensor =>
            {
                sensor.AttachAlarm(enhancedAlarmFactory.CreateVisibleAlarm());
                sensor.AttachAlarm(enhancedAlarmFactory.CreateAudibleAlarm());
            });
            sensorCabinet = new(sensorCollection);
            sensorCabinet.TestAlarms();
        }
    }
}