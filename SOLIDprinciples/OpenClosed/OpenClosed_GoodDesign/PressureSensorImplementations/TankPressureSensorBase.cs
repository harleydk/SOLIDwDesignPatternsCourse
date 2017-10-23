namespace OpenClosed_GoodDesign.PressureSensorImplementations
{
    /// <summary>
    /// The tank-pressure sensor abstraction, that allows our PressureSensorReader to read the sensor's values in a similar fashion, across sensor implementations.
    /// </summary>
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