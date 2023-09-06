using System.Diagnostics;

namespace OpenClosed_BadDesign
{
    public sealed class Program
    {
        /// <summary>
        /// The Open/Closed Principle states that a component should be closed for modification, but open for extentions. In the below, a PressureSensorReader 'news up' a number of sensors, wherefore we would need open it up in case we need to modify it.
        /// </summary>
        public static void Main()
        {
            PressureSensorReader pressureSensorReader = new();

            int waterIntakeVelocity = 16;
            var averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);
            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");
        }
    }
}