using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;
using System;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public sealed class InternalTankPressureSensor : AbstractTankPressureSensor
    {
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(TankOutletSizeCalculatorEnum tankOutletSizeCalculatorEnum, int tankCapacity = 3, int tankDiameter = 10 ) : base(tankOutletSizeCalculatorEnum, tankCapacity, tankDiameter)
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