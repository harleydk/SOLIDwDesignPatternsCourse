namespace DependencyInversion_BadDesign
{
    public static class Program
    {
        /// <summary>
        /// The dependency inversion principle states that a class should not declare its own dependencies - rather it 
        /// should be provided with them. 
        /// 
        /// Below is a bad example: a SensorCabinet declares a number of dependencies within its own constructor, 
        /// wherefore it becomes hard-coupled to these dependencies.
        /// </summary>
        public static void Main()
        {

            // Initialization. Lots of hidden dependencies within.
            SensorCabinet sensorCabinet = new();
          
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            sensorCabinet.AttachLogger();
            sensorCabinet.WriteAllTemperatureSensorsDataToLog();

            // Introducing Lab1 - introduce a better design.
            // The tasks are as follows:
            // - Find a way to initialize the SensorCabinet's dependencies - i.e. sensors and alarms - without having to 'new them up' from the constructor.
            // - Find a way to attach the logger from outside of the SensorCabinet, so that object is not in charge of it.
            // - 
        }
    }
}