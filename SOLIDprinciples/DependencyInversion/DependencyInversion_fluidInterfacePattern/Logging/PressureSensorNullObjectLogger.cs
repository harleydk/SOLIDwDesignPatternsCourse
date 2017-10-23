namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class PressureSensorNullObjectLogger : PressureSensorLogger
    {
        public PressureSensorNullObjectLogger() : base(new DiagnosticsNullObjectLogger())
        {
        }
    }
}