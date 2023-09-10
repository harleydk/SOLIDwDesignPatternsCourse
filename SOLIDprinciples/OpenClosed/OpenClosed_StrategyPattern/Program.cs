using System.Diagnostics;

namespace OpenClosed_StrategyPattern
{
    /// <summary>
    /// The plot thickens... We ship our pressure-sensor-reader to USA, and am now under obligation to calculate different tank sizes (and thus the average pressures will be different), depending on where in the world our tanks are located.
    ///
    /// We could do different tank-implementations - but it's only GetTankOutletSize() that changes.
    /// </summary>
    public sealed class Program
    {
        public static void Main()
        {
            PressureSensorReader pressureSensorReader = new();

            int waterIntakeVelocity = 16;
            double averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);

            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");
        }
    }
}