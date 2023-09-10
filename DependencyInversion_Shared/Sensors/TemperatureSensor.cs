using System;

namespace DependencyInversion
{
    public sealed class TemperatureSensor : Sensor
    {
        public string Id { get; private set; }

        public TemperatureSensor(string sensorId)
        {
            Id = sensorId;
        }

        /// <summary>
        /// Get the current temperature of the sensor.
        /// </summary>
        /// <returns>the current temperature</returns>
        /// <remarks>
        /// <i>We'll just pretend we're physically hooked up to a sensor, and that this method will return its current temperature.</i>
        /// </remarks>
        public double GetTemperature()
        {
            Random rnd = new();
            return rnd.NextDouble();
        }
    }
}