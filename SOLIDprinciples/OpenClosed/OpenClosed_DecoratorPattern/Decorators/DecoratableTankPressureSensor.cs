namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    public abstract class DecoratableTankPressureSensor : AbstractTankPressureSensor
    {
        public AbstractTankPressureSensor _abstractTankPressureSensor;

        public DecoratableTankPressureSensor(AbstractTankPressureSensor abstractTankPressureSensor)
        {
            _abstractTankPressureSensor = abstractTankPressureSensor;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            return _abstractTankPressureSensor.CalculatePressure(waterIntakeVelocity);
        }
    }
}
