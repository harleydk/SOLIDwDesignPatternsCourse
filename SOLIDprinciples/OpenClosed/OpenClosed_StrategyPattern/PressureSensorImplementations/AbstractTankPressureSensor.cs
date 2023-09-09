using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public abstract class AbstractTankPressureSensor
    {
        private readonly int _tankCapacity = 10;
        private readonly int _tankDiameter = 3;

        private readonly ITankOutletSizeCalculateStrategy _tankOutletSizeCalculateStrategy;

        public AbstractTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10, ITankOutletSizeCalculateStrategy tankOutletSizeCalculateStrategy = null)
        {
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;

            // guard clause
            if (tankOutletSizeCalculateStrategy == null)
                _tankOutletSizeCalculateStrategy = new DefaultTankOutletSizeCalculateStrategy();
            else
                _tankOutletSizeCalculateStrategy = tankOutletSizeCalculateStrategy;
        }

        public abstract double CalculatePressure(int waterIntakeVelocity);

        // Our signature appears the same, but its execution will wary at run time. That's the advantage - 
        // otherwise the different calculations would go into the classes and we've have to have 
        // two * internalTankPressureSensor classes and two * externalTankPressureSensor, each with their own
        // GetTankOutletSize() functions
        protected double GetTankOutletSize()
        {
            double tankOutletSize = _tankOutletSizeCalculateStrategy.CalculateTankOutletSize(_tankCapacity, _tankDiameter);
            return tankOutletSize;
        }
    }
}
