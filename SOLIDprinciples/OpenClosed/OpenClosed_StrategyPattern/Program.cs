using OpenClosed_StrategyPattern.PressureSensorImplementations;
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;
using System.Diagnostics;

namespace OpenClosed_StrategyPattern
{
    /// <summary>
    /// The plot thickens!: We now sell our pressure-sensor-reader to USA, and am now under obligation to calculate different 
    /// tank sizes (and thus the average pressures will be different), depending on where in the world our tanks are located.
    ///
    /// We could do several new different tank-implementations, i.e. "InternalTankPressureSensorUS" and 
    /// "InternalTankPressureSensorRestOfTheWorld" - but it's only GetTankOutletSize() that changes, so seems like overkill.
    /// No worries: we can infuse our <see cref="TankPressureSensorBase"/> with a <see cref="ITankSizeStrategy"/>, 
    /// so we don't have to make new near copies of classes, but maintain just one - that we thus keep open for extention.
    /// </summary>
    public sealed class Program
    {
        public static void Main()
        {
            ITankSizeStrategy UnitedStatesTankSizeStrategy = new UnitedStatesTankSizeStrategy();

            TankPressureSensorBase[] tankPressureSensors =
                {
                    new InternalTankPressureSensor(tankCapacity: 4),
                    new InternalTankPressureSensor(tankDiameter: 15, tankSizeStrategy: UnitedStatesTankSizeStrategy),
                    new ExternalTankPressureSensor(tankCapacity: 1, tankDiameter: 100)
                };
            PressureSensorReader pressureSensorReader = new(tankPressureSensors);
            
            int waterIntakeVelocity = 16;
            double averagePressureAcrossSensors = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);
            Debug.WriteLine($"Average pressure across all pressure sensors is {averagePressureAcrossSensors}");
        }
    }
}