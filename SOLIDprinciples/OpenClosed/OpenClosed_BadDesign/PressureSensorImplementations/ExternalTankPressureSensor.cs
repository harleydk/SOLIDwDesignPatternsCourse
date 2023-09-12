namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public sealed class ExternalTankPressureSensor : TankPressureSensorBase
    {
        private const int TANK_ISOLATION_IMPEDANCE = 3;
        private const int TANK_ISOLATION_THICKNESS = 42;

        public ExternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10):
               base(tankCapacity, tankDiameter)
        {
        }

        public double GetTankIsolationFactor()
        {
            return (double)TANK_ISOLATION_THICKNESS / TANK_ISOLATION_IMPEDANCE;
        }
    }
}
