namespace OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies
{
    public sealed class DefaultTankOutletSizeCalculateStrategy : ITankOutletSizeCalculateStrategy
    {
        public double CalculateTankOutletSize(int tankCapacity, int tankDiameter)
        {
            double tankOutletSize = (double)tankCapacity / tankDiameter;
            return tankOutletSize;
        }
    }
}
