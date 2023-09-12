using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public abstract class TankPressureSensorBase
    {
        protected readonly int _tankCapacity = 10;
        protected readonly int _tankDiameter = 3;

        /// <summary>
        /// A <see cref="ITankSizeStrategy"/> implementation, injected at object creation.
        /// </summary>
        private readonly ITankSizeStrategy _tankOutletSizeCalculateStrategy;

        public TankPressureSensorBase(int tankCapacity = 3, int tankDiameter = 10, ITankSizeStrategy tankOutletSizeCalculateStrategy = null)
        {
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;

            if (tankOutletSizeCalculateStrategy == null)
            {
                _tankOutletSizeCalculateStrategy = new DefaultTankOutletSizeCalculateStrategy(); // Guard clause
            }
            else
            {
                _tankOutletSizeCalculateStrategy = tankOutletSizeCalculateStrategy;
            }
        }

        public abstract double CalculatePressure(int waterIntakeVelocity);

        /// <summary>
        /// Our method body appears the same, but its execution will wary according
        /// to the <see cref="ITankSizeStrategy"/> implementation. That's a big advantages -
        /// otherwise the different calculations would have to go into the classes and we've have to have 
        /// two * <see cref="InternalTankPressureSensor"/> classes and two * <see cref="ExternalTankPressureSensor"/>, 
        /// each with their own <see cref="GetTankOutletSize"/>() functions
        /// </summary>
        protected double GetTankOutletSize()
        {
            double tankOutletSize = _tankOutletSizeCalculateStrategy.CalculateTankOutletSize(_tankCapacity, _tankDiameter);
            return tankOutletSize;
        }
    }
}
