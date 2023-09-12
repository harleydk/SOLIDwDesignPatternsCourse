namespace OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies
{
    public sealed class DefaultTankOutletSizeCalculateStrategy : ITankSizeStrategy
    {
        public double CalculateTankOutletSize(int tankCapacity, int tankDiameter)
        {
            double tankOutletSize = (double)tankCapacity / tankDiameter;
            return tankOutletSize;
        }
    }
}
