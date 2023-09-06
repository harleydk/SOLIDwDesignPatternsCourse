namespace DependencyInversion_BadDesign
{
    public static class Program
    {
        /// <summary>
        /// The dependency inversion principle states that a class should not declare its own dependencies - rather it should be provided with them. Below, a SensorCabinet declares a number of dependencies within its own confines, wherefore it becomes hard-coupled to these dependencies.
        /// </summary>
        public static void Main()
        {
            SensorCabinet sensorCabinet = new();
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            sensorCabinet.AttachLogger();
            sensorCabinet.WriteAllTemperatureSensorsDataToLog();

            // Introducing Lab1 - introduce a better design.
        }
    }
}