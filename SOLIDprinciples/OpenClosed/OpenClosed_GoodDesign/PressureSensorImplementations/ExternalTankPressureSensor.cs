
namespace OpenClosed_GoodDesign.PressureSensorImplementations
{
    public sealed class ExternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_ISOLATION_IMPEDANCE = 3;
        private const int TANK_ISOLATION_THICKNESS = 42;

        public ExternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10) : base(tankCapacity, tankDiameter)
        {
        }

        private double getTankIsolationFactor()
        {
            return (double)TANK_ISOLATION_THICKNESS / TANK_ISOLATION_IMPEDANCE;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            double tankOutletSize = CalculateTankOutletSize();
            double tankIsolationFactor = getTankIsolationFactor();
            double totallyBogusPressureValue = tankIsolationFactor * tankOutletSize;
            return totallyBogusPressureValue;
        }
    }
}
