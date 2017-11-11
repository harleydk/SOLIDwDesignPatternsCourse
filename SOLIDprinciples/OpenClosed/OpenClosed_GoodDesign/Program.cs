using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    public sealed class Program
    {
        /// <summary>
        /// In order to accomodate the open/closed principle, we introduce an abstraction that will allow our PressureSensorReader to read pressures in the same way across the various sensors.
        /// </summary>
        public static void Main()
        {
            PressureSensorReader pressureSensorReader = new PressureSensorReader();

            int waterIntakeVelocity = 16;
            var averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);
            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");

            // Given the introduction of the 'AbstractTankPressureSensor' abstraction,
            // the class is now closed for modification but open for extension - in as much as introducing a new type of sensor requires it implementing the abstract base-class, thus the PressureSensorReader will still function as expected.

            // Though, it still "new's up" those sensors... that's a hard coupling, we would preferably like to avoid.
            // We can apply the Dependency Inversion-principle - and that's coming right up.
        }
    }
}