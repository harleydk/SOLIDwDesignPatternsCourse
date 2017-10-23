namespace SingleResponsibility_FacadePattern
{
    public sealed class Program
    {
        /// <summary>
        /// What if we can't seperate the diverse responsibilities - if we absolutely _must_ present a single common class, perhaps in order to fulfill a previously arranged contract? We can use the Facade Pattern to enable seperation of concerns, yet still combine them to present a common front.
        /// </summary>
        private static void Main()
        {
            SensorAndLoggerFacade sensorAndLoggerFacade = new SensorAndLoggerFacade();
            string sensorValue = sensorAndLoggerFacade.ReadSensorValue();
            sensorAndLoggerFacade.WriteToLog(sensorValue);
        }
    }
}