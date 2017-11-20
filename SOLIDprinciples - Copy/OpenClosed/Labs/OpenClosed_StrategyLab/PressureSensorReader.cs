using OpenClosed_StrategyPattern.PressureSensorImplementations;
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern
{
    public sealed class PressureSensorReader
    {
        private AbstractTankPressureSensor[] _tankPressureSensors;

        public PressureSensorReader()
        {
            _tankPressureSensors = new AbstractTankPressureSensor[]
            {
                new InternalTankPressureSensor(TankOutletSizeCalculatorEnum.Default, tankCapacity: 4),
                new InternalTankPressureSensor(TankOutletSizeCalculatorEnum.US, tankDiameter: 15),
                new ExternalTankPressureSensor(TankOutletSizeCalculatorEnum.Default, 1,100)
             };
        }

        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            double totalPressureFromAllSensors = 0;

            foreach (var tankPressureSensor in _tankPressureSensors)
                totalPressureFromAllSensors += tankPressureSensor.CalculatePressure(waterIntakeVelocity);

            int numberOfPressureSensores = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensores;
            return averagePressureAcrossSensors;
        }

        // Advantage? Our tank-implementations the same, we've merely added to their constructors. We only took that which changed, and abstracted away.
        // Disadvantages? Readability suffers slightly.
    }
}