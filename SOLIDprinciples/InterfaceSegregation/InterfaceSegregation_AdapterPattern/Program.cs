using System.Collections.Generic;
using System.Diagnostics;

namespace InterfaceSegregation_AdapterPattern
{
    public sealed class Program
    {
        private static IEnumerable<ISensor> listOfSensors = new List<ISensor>();

        private static ICabinetSensorEventing cheapChineseSensorCabinet = new CheapChineseSensorCabinetAdapter(listOfSensors);

        /// <summary>
        /// Let's say we're suddenly faced with having to integrate a cheap chinese cabinet - but it implements an old interface, that we sent out into the world. But we would rather like to have the chinese version live off our differentiated interface, so as to curb our maintainability issues later down the road.
        /// By way of the adapter design-pattern, we can do this.
        /// </summary>
        public static void Main()
        {
            cheapChineseSensorCabinet.SensorEvent += SensorCabinetWithPreloadedSensors_SensorEvent;
        }

        private static void SensorCabinetWithPreloadedSensors_SensorEvent(object sender, SensorEventArgs sensorEventArgs)
        {
            Debug.WriteLine($"Logging sensor {sensorEventArgs.SensorId}'s value of {sensorEventArgs.SensorValue}");
        }
    }
}