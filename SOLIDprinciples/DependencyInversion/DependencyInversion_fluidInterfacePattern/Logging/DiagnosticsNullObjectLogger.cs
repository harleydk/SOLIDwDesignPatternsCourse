namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class DiagnosticsNullObjectLogger : DiagnosticsLogger
    {
        public new void WriteToLog(string logMessage)
        {
            // null-object entity - no actions undertaken.
        }
    }
}