using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies
{
    public interface ITankSizeStrategy
    {
        double CalculateTankOutletSize(int tankCapacity, int tankDiameter);
    }
}
