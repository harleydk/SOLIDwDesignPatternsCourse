using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;
using System;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public sealed class InternalTankPressureSensor : AbstractTankPressureSensor
    {
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10, ITankOutletSizeCalculateStrategy tankOutletSizeCalculateStrategy = null) : base(tankCapacity, tankDiameter, tankOutletSizeCalculateStrategy)
        {
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            double internalTankoutletSize = GetTankOutletSize();
            double totallyBogusPressureValue = (TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankoutletSize;
            return totallyBogusPressureValue;
        }
    }
}