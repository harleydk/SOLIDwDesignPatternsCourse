
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public sealed class ExternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_ISOLATION_IMPEDANCE = 3;
        private const int TANK_ISOLATION_THICKNESS = 42;

        public ExternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10, ITankSizeStrategy tankOutletSizeCalculateStrategy = null) : 
            base(tankCapacity, tankDiameter, tankOutletSizeCalculateStrategy)
        {
        }

        private double getTankIsolationFactor()
        {
            return (double)TANK_ISOLATION_THICKNESS / TANK_ISOLATION_IMPEDANCE;
        }

        // Note - GetTankPressure() had its name changed to CalculatePressure(), to honor the base-class. 
        public override double CalculatePressure(int waterIntakeVelocity)
        {
            double tankOutletSize = GetTankOutletSize();
            double tankIsolationFactor = getTankIsolationFactor();
            double totallyBogusPressureValue = tankIsolationFactor * tankOutletSize;
            return totallyBogusPressureValue;
        }
    }
}
