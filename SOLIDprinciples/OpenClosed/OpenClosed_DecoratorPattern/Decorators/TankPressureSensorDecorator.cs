namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    /// <summary>
    /// This <see cref="TankPressureSensorDecorator"/> holds a <see cref="TankPressureSensorBase"/> implementation
    /// as a private field. By implementing this abstract class, we can keep adding relevant logic in regards to
    /// the <see cref="CalculatePressure(int)"/>; each referenced implementation will reference - or
    /// 'decorate' - the implementation it's based on - as best seen in the <see cref="Program.Main"/> method.
    /// </summary>
    public abstract class TankPressureSensorDecorator : TankPressureSensorBase
    {
        private readonly TankPressureSensorBase _abstractTankPressureSensor;

        public TankPressureSensorDecorator(TankPressureSensorBase abstractTankPressureSensor)
        {
            _abstractTankPressureSensor = abstractTankPressureSensor;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            return _abstractTankPressureSensor.CalculatePressure(waterIntakeVelocity);
        }
    }
}
