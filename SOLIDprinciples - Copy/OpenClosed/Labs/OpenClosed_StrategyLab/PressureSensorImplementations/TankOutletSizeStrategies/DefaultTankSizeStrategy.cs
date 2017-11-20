using System;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies
{
    public sealed class DefaultTankOutletSizeCalculateStrategy : ITankOutletSizeCalculateStrategy
    {
        public double CalculateTankOutletSize(int tankCapacity, int tankDiameter)
        {
            double tankOutletSize = (double)tankCapacity / tankDiameter;
            return tankOutletSize;
        }

        public bool IsStrategyMatch(TankOutletSizeCalculatorEnum tankOutletSizeCalculatorEnum)
        {
            bool isStrategyMatch = tankOutletSizeCalculatorEnum == TankOutletSizeCalculatorEnum.Default;
            return isStrategyMatch;
        }
    }
}
