namespace OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies
{
    public sealed class UnitedStatesTankSizeStrategy : ITankSizeStrategy
    {
        private const double US_TANK_OUTLET_SIZE_MODIFIER = 1.1d;

        public double CalculateTankOutletSize(int tankCapacity, int tankDiameter)
        {
            double tankOutletSize = (double)tankCapacity / tankDiameter;
            return tankOutletSize * US_TANK_OUTLET_SIZE_MODIFIER;
        }
    }
}
