using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    public sealed class InternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10) : base(tankCapacity, tankDiameter)
        {
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            Debug.WriteLine($"Called CalculatePressure() on {this.GetType().Name}");

            double internalTankoutletSize = CalculateTankOutletSize();
            double totallyBogusPressureValue = (TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankoutletSize;
            return totallyBogusPressureValue;
        }

    }
}