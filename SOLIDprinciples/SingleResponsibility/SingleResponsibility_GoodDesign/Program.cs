namespace SingleResponsibility_GoodDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The best solution to the SensorReader's multiple responsibilities is to simply seperate them.
        /// </summary>
        private static void Main()
        {
            // Separating the concerns is better:
            SensorReader sensorReader = new();
            string sensorValue = sensorReader.ReadSensorValue();

            FileLogger filelOgger = new();
            filelOgger.WriteToLog(sensorValue);
        }
    }
}