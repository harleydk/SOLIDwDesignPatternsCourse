using OpenClosed_StrategyPattern.PressureSensorImplementations;
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern
{
    public sealed class PressureSensorReader
    {
        private readonly AbstractTankPressureSensor[] _tankPressureSensors;

        public PressureSensorReader()
        {
            // we explicitely determine a strategy for further calculation:
            ITankOutletSizeCalculateStrategy UStankOutletCalculatorStrategy = new USTankOutletSizeCalculateStrategy();

            _tankPressureSensors = new AbstractTankPressureSensor[]
            {
                new InternalTankPressureSensor(tankCapacity: 4),
                new InternalTankPressureSensor(tankDiameter: 15, tankOutletSizeCalculateStrategy: UStankOutletCalculatorStrategy),
                new ExternalTankPressureSensor(1,100)
             };
        }

        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            double totalPressureFromAllSensors = 0;

            foreach (AbstractTankPressureSensor tankPressureSensor in _tankPressureSensors)
                totalPressureFromAllSensors += tankPressureSensor.CalculatePressure(waterIntakeVelocity);

            int numberOfPressureSensores = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensores;
            return averagePressureAcrossSensors;
        }

        // Advantage? Our tank-implementations the same, we've merely added to their constructors. We only took that which changed, and abstracted away.
        // Disadvantages? Readability suffers slightly.
    }
}