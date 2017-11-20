namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class TemperatureSensorNullObjectLogger : TemperatureSensorLogger
    {
        public TemperatureSensorNullObjectLogger() : base(new DiagnosticsNullObjectLogger())
        {
        }
    }
}