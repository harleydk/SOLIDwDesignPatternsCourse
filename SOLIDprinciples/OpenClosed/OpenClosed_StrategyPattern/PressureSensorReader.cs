using OpenClosed_StrategyPattern.PressureSensorImplementations;
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern
{
    /// <summary>
    /// The <see cref="PressureSensorReader"/> remains the same as in the 'good' example; everything
    /// in regards to the different <see cref="ITankSizeStrategy"/> concerns happens in the creation
    /// of the <see cref="TankPressureSensorBase"/> implementations, i.e. we inject a suitable strategy 
    /// via their constructors.
    /// </summary>
    public sealed class PressureSensorReader
    {
        private readonly TankPressureSensorBase[] _tankPressureSensors;

        public PressureSensorReader(TankPressureSensorBase[] tankPressureSensors)
        {
            _tankPressureSensors = tankPressureSensors;
        }

        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            double totalPressureFromAllSensors = 0;

            foreach (TankPressureSensorBase tankPressureSensor in _tankPressureSensors)
                totalPressureFromAllSensors += tankPressureSensor.CalculatePressure(waterIntakeVelocity);

            int numberOfPressureSensors = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensors;
            return averagePressureAcrossSensors;
        }
    }
}