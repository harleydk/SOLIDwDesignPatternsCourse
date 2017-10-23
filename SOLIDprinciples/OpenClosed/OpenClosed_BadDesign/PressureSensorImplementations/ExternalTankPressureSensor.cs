using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public sealed class ExternalTankPressureSensor
    {
        private readonly int _tankCapacity = 10;
        private readonly int _tankDiameter = 3;

        private const int TANK_ISOLATION_IMPEDANCE = 3;
        private const int TANK_ISOLATION_THICKNESS = 42;

        public ExternalTankPressureSensor(int tankCapacity = 3, int tankDiameter = 10)
        {
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;

        }

        private double getTankOutletSize()
        {
            double tankOutletSize = (double)_tankCapacity / _tankDiameter;
            return tankOutletSize;
        }

        private double getTankIsolationFactor()
        {
            return (double)TANK_ISOLATION_THICKNESS / TANK_ISOLATION_IMPEDANCE;
        }

        public double GetTankPressure(int waterIntakeVelocity)
        {
            double tankOutletSize = getTankOutletSize();
            double tankIsolationFactor = getTankIsolationFactor();
            double totallyBogusPressureValue = tankIsolationFactor * tankOutletSize;
            return totallyBogusPressureValue;
        }


    }

}
