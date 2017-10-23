using System.Collections.Generic;
using System.Diagnostics;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class Program
    {
        // By segregation the ICabinetSensorEventing interface in the 'BetterDesign' solution even further, we can more easily make up a class without any unnecessary dependencies. As we should try to do, because the concerns of adding sensors and reacting to events from them are different concerns.
        private static IEnumerable<ISensor> listOfSensors = new List<ISensor>();
        
        // This new kind of SensorCabinet only needs implement the ICabinetSensorEventing interface - as it comes with pre-loaded sensors, and thus doesn't require the stuff in the ICabinetSensorAttaching interface.
        private static ICabinetSensorEventing sensorCabinetWithPreloadedSensors = new SensorCabinetWithPreloadedSensors(listOfSensors);

        public static void Main()
        {
            sensorCabinetWithPreloadedSensors.SensorEvent += SensorCabinetWithPreloadedSensors_SensorEvent;
        }

        private static void SensorCabinetWithPreloadedSensors_SensorEvent(object sender, SensorEventArgs sensorEventArgs)
        {
            Debug.WriteLine($"Logging sensor {sensorEventArgs.SensorId}'s value of {sensorEventArgs.SensorValue}");
        }
    }
}