using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    public sealed class ShockAbsorbableTankPressureSensor : DecoratableTankPressureSensor
    {
        private readonly double _maXAllowableGForceLoad = 5d;
        private const double PRESSURE_INCREASE_FACTOR_IF_SHOCKABSORBABLE = 1.1;

        public ShockAbsorbableTankPressureSensor(AbstractTankPressureSensor abstractTankPressureSensor, double? maXAllowableGForceLoad = null) : base(abstractTankPressureSensor)
        {
            if (maXAllowableGForceLoad != null)
                _maXAllowableGForceLoad = maXAllowableGForceLoad.Value;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            Debug.WriteLine($"Called CalculatePressure() on {this.GetType().Name}");

            bool isShockAbsorbant = Is5GShockAbsorbant();
            if (isShockAbsorbant)
                return base.CalculatePressure(waterIntakeVelocity) * PRESSURE_INCREASE_FACTOR_IF_SHOCKABSORBABLE;
            else
                return base.CalculatePressure(waterIntakeVelocity);
        }

        private bool Is5GShockAbsorbant()
        {
            bool isShorkAbsorbantUpTo5G = _maXAllowableGForceLoad < 5d;
            return isShorkAbsorbantUpTo5G;
        }
    }
}