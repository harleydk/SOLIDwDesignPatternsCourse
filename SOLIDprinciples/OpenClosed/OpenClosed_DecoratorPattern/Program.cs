using OpenClosed_DecoratorPattern.PressureSensorImplementations;
using System.Diagnostics;

namespace OpenClosed_DecoratorPattern
{
    public static class Program
    {
        /// <summary>
        /// Now we're in the need to implement a tank-pressure sensor that takes into account temperatures, shock-absorbability, etc. 
        /// We can't keep on sub-classing AbstractTankPressureSensor's - we'd drown in implementations. Instead, we can use the 
        /// <i>decorator pattern</i> to add behavior, rather than continuously sub-classing.
        /// </summary>
        /// <remarks>
        /// The advantage of the decorator pattern is in how we can truly abstract away only that code which changes, in this case 
        /// the individual pressure-calculating logic.
        /// </remarks>
        public static void Main()
        {
            TankPressureSensorBase internalTankPressureSensor = new InternalTankPressureSensor(tankCapacity: 4);

            TankPressureSensorBase shockAbsorbableInternalTankPressureSensor =
                new ShockAbsorbableTankPressureSensor( maXAllowableGForceLoad: 10, internalTankPressureSensor);

            TankPressureSensorBase shockAbsorbableInternalTankPressureSensorWithTemperature =
                new TemperatureTankPressureSensor(minimumDegreesCelsius: 10, maxDegreesCelsius: 12, shockAbsorbableInternalTankPressureSensor);

            TankPressureSensorBase[] tankPressureSensors = { shockAbsorbableInternalTankPressureSensorWithTemperature /* Just one sensor, for the case of this example. */ };

            PressureSensorReader pressureSensorReader = new(tankPressureSensors);
            double averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(10);
            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");
        }
    }
}