namespace DependencyInversion_BadDesign
{
    public static class Program
    {
        /// <summary>
        /// The dependency inversion principle states that a class should not declare its own dependencies - rather it should be provided with them. 
        /// 
        /// Below, a poor example: A SensorCabinet declares a number of dependencies within its own confines, wherefore it becomes hard-coupled to these dependencies.
        /// </summary>
        public static void Main()
        {
            // Initialization. Within these methods, there's a lot of creation logic going on.
            SensorCabinet sensorCabinet = new();
            sensorCabinet.InitializeAlarms();
            sensorCabinet.InitializeSensors();
            sensorCabinet.AttachAlarmsToSensors();

            // At some point, we wish to write temperature sensor values to a log.
            sensorCabinet.AttachLogger();
            sensorCabinet.WriteAllTemperatureSensorsDataToLog();

            // Introducing Lab1 - introduce a better design.
        }
    }
}