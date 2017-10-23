
using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    public sealed class ExternalTankPressureSensor : AbstractTankPressureSensor
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

        // Note - GetTankPressure() had its name changed to CalculatePressure(), to honor the base-class. 
        public override double CalculatePressure(int waterIntakeVelocity)
        {
            Debug.WriteLine($"Called CalculatePressure() on {this.GetType().Name}");

            double tankOutletSize = CalculateTankOutletSize();
            double tankIsolationFactor = getTankIsolationFactor();
            double totallyBogusPressureValue = tankIsolationFactor * tankOutletSize;
            return totallyBogusPressureValue;
        }
    }
}
