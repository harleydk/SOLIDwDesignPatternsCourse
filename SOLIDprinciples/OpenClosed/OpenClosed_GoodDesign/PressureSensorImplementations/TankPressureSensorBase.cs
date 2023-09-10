﻿namespace OpenClosed_GoodDesign.PressureSensorImplementations
{
    /// <summary>
    /// By moving the individual 'CalculatePressure' concerns into the base-class, we can forego
    /// taking the distinct tankPressureSensor-implementations into account when the PressureSensorReader
    /// calculates the combined pressures.
    /// </summary>
    public abstract class TankPressureSensorBase
    {
        protected readonly int _tankCapacity = 10;
        protected readonly int _tankDiameter = 3;

        public TankPressureSensorBase(int tankCapacity = 3, int tankDiameter = 10)
        {
            _tankCapacity = tankCapacity;
            _tankDiameter = tankDiameter;
        }

        public virtual double CalculateTankOutletSize()
        {
            double tankOutletSize = (double)_tankCapacity / _tankDiameter;
            return tankOutletSize;
        }

        public abstract double CalculatePressure(int waterIntakeVelocity);
    }
}