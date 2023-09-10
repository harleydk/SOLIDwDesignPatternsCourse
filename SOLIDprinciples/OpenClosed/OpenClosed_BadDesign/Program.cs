using OpenClosed_BadDesign.PressureSensorImplementations;
using System.Diagnostics;

namespace OpenClosed_BadDesign
{
    /// <summary>
    /// The Open/Closed Principle states that a component should be closed for modification, but open for extensions. In the below, 
    /// a PressureSensorReader 'news up' a number of sensors - wherefore we would need open it up in case we need to modify it.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Main()
        {
            TankPressureSensorBase[] tankPressureSensors = 
            {
                new InternalTankPressureSensor(tankCapacity: 4),
                new InternalTankPressureSensor(tankDiameter: 15),
                new ExternalTankPressureSensor(1, 100)
            };
            PressureSensorReader pressureSensorReader = new(tankPressureSensors);

            int waterIntakeVelocity = 16;
            double averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);
            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");
        }
    }
}