namespace OpenClosed_BadDesign.PressureSensorImplementations
{
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

    }
}
