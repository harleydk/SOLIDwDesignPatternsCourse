namespace OpenClosed_DecoratorPattern
{
    public static class Program
    {
        /// <summary>
        /// Now we're in the need to implement a tank-pressure sensor that takes into account temperatures, shock-absorbability, etc. We can't keep on sub-classing AbstractTankPressureSensor's - we'd drown in implementations. Instead, we can use the decorator pattern to add behaviour, rather than sub-classing all the time.
        /// </summary>
        public static void Main()
        {
            PressureSensorReader pressureSensorReader = new PressureSensorReader();
            pressureSensorReader.GetAveragePressureAcrossSensors(10);
        }
    }
}