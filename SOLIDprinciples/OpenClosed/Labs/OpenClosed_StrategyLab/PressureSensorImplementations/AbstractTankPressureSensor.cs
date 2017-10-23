
using System;
using OpenClosed_StrategyPattern.PressureSensorImplementations.TankOutletSizeStrategies;
using System.Collections.Generic;
using System.Linq;

namespace OpenClosed_StrategyPattern.PressureSensorImplementations
{
    public enum TankOutletSizeCalculatorEnum
    {
        Default,
        US
    }

    public abstract class AbstractTankPressureSensor
    {
        private readonly int _tankCapacity = 10;
        private readonly int _tankDiameter = 3;
        private TankOutletSizeCalculatorEnum _tankOutletSizeCalculatorEnum;

        private IEnumerable<ITankOutletSizeCalculateStrategy> _tankOutletSizeCalculateStrategies;

        private void Initialize()
        {
            _tankOutletSizeCalculateStrategies = new List<ITankOutletSizeCalculateStrategy>()
            {
                 new DefaultTankOutletSizeCalculateStrategy(),
                 new USTankOutletSizeCalculateStrategy()
            };
        }

        public AbstractTankPressureSensor(TankOutletSizeCalculatorEnum tankOutletSizeCalculatorEnum, int tankCapacity = 3, int tankDiameter = 10)
        {
            Initialize();

            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;

            _tankOutletSizeCalculatorEnum = tankOutletSizeCalculatorEnum;
        }

        public abstract double CalculatePressure(int waterIntakeVelocity);

        protected double GetTankOutletSize()
        {
            ITankOutletSizeCalculateStrategy selectedStrategy = _tankOutletSizeCalculateStrategies.Single(strategy => strategy.IsStrategyMatch(_tankOutletSizeCalculatorEnum));

            double tankOutletSize = selectedStrategy.CalculateTankOutletSize(_tankCapacity, _tankDiameter);
            return tankOutletSize;
        }
    }
}
