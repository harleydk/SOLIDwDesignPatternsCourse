namespace OpenClosed_BadDesign
{
    public sealed class InternalTankPressureSensor
    {
        private readonly int _tankCapacity = 10;
        private readonly int _tankDiameter = 3;
        private const int TANK_INTERNAL_THICKNESS = 15;

        public InternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10)
        {
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;
        }

        private double getTankOutletSize()
        {
            double tankOutletSize = (double) _tankCapacity / _tankDiameter;
            return tankOutletSize;
        }

        public double CalculatePressure(int waterIntakeVelocity)
        {
            double internalTankoutletSize = getTankOutletSize();
            double totallyBogusPressureValue = (TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankoutletSize;
            return totallyBogusPressureValue;
        }
    }
}