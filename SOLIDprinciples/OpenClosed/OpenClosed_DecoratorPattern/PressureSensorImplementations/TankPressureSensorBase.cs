
using System;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{

    public abstract class TankPressureSensorBase 
    {
    
        private readonly int _tankCapacity = 10;
        private readonly int _tankDiameter = 3;

        public TankPressureSensorBase(int tankCapacity = 3, int tankDiameter = 10)
        {
        
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;
        }

        protected double CalculateTankOutletSize()
        {
            double tankOutletSize = (double)_tankCapacity / _tankDiameter;
            return tankOutletSize;
        }

        public abstract double CalculatePressure(int waterIntakeVelocity);
    }
}
