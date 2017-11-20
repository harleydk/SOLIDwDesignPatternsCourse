namespace SingleResponsibility_FacadePattern
{
    // Combines the two classes into a common front. Uses simple pass-through - there are better ways - but
    // it works, and we've managed to seperate the responsibilities of the original class and will have a better
    // way of maintaining them onwards.
    public sealed class SensorAndLoggerFacade
    {
        private FileLogger logger = new FileLogger();
        private SensorReader sensorReader = new SensorReader();

        public void WriteToLog(string message)
        {
            // simple pass-through
            logger.WriteToLog(message);
        }

        public string ReadSensorValue()
        {
            // simple pass-through
            return sensorReader.ReadSensorValue();
        }
    }
}