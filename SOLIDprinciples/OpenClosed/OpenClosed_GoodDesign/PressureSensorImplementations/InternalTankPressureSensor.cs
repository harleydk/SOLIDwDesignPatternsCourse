namespace OpenClosed_GoodDesign.PressureSensorImplementations
{
    public sealed class InternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10) : 
            base(tankCapacity, tankDiameter)
        {
        }

        public override double CalculateTankOutletSize()
        {
            double tankOutletSize = ((double)_tankCapacity / _tankDiameter) * 2;
            return tankOutletSize;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            double internalTankOutletSize = CalculateTankOutletSize();
            double totallyBogusPressureValue = (TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankOutletSize;
            return totallyBogusPressureValue;
        }
    }
}