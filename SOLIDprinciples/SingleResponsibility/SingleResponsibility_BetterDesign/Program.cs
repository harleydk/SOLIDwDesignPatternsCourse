namespace SingleResponsibility_BetterDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The best solution to the SensorReader's multiple responsibilities is to simply seperate them.
        /// </summary>
        private static void Main()
        {
            // Separating the concerns is better:
            SensorReader sensorReader = new SensorReader();
            string sensorValue = sensorReader.ReadSensorValue();

            FileLogger filelOgger = new FileLogger();
            filelOgger.WriteToLog(sensorValue);
        }
    }
}