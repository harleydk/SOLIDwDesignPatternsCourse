namespace SingleResponsibility_BadDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The Single Responsibility principle states that a class should have only one reason to change. In the below, the SensorReader has two responsibilities, namely reading a sensor value and reporting it to a log.
        /// </summary>
        private static void Main()
        {
            SensorReader sensorReader = new SensorReader();
            string sensorValue = sensorReader.ReadSensorValue();
            sensorReader.WriteSensorValueToLog(sensorValue);
        }
    }
}