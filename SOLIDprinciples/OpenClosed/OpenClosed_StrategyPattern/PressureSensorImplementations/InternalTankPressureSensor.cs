using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public sealed class InternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10, ITankSizeStrategy tankSizeStrategy = null) : 
            base(tankCapacity, tankDiameter, tankSizeStrategy)
        {
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            double internalTankOutletSize = GetTankOutletSize();
            double totallyBogusPressureValue = (TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankOutletSize;
            return totallyBogusPressureValue;
        }
    }
}