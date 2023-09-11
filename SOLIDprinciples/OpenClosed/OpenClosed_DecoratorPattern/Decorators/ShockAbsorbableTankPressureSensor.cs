using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    public sealed class ShockAbsorbableTankPressureSensor : TankPressureSensorDecorator
    {
        private const double PRESSURE_INCREASE_FACTOR_IF_SHOCKABSORBABLE = 1.1;

        private readonly double _maXAllowableGForceLoad = 5d;

        public ShockAbsorbableTankPressureSensor(double? maXAllowableGForceLoad, TankPressureSensorBase abstractTankPressureSensor) :
            base(abstractTankPressureSensor)
        {
            _maXAllowableGForceLoad = maXAllowableGForceLoad.Value;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            Debug.WriteLine($"Called CalculatePressure() on {this.GetType().Name}");

            bool isShockAbsorbent = Is5GShockAbsorbent();
            if (isShockAbsorbent)
                return base.CalculatePressure(waterIntakeVelocity) * PRESSURE_INCREASE_FACTOR_IF_SHOCKABSORBABLE;
            else
                return base.CalculatePressure(waterIntakeVelocity);
        }

        private bool Is5GShockAbsorbent()
        {
            bool isShockAbsorbentUpTo5G = _maXAllowableGForceLoad < 5d;
            return isShockAbsorbentUpTo5G;
        }
    }
}