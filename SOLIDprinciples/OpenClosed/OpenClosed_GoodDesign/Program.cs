using OpenClosed_GoodDesign.PressureSensorImplementations;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    public sealed class Program
    {
        /// <summary>
        /// In order to accommodate the open/closed principle, we move common concerns - i.e. the CalculatePressure-logic - into the 
        /// abstract <see cref="TankPressureSensorBase"/> class. This opens the class up to extensions by injection of multiple and 
        /// different sensors, and closes it for modification since the calculations are performed outside of the <see cref="PressureSensorReader" />.
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