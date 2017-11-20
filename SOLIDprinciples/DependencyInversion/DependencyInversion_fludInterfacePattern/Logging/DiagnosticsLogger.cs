using System.Diagnostics;

namespace DependencyInversion_fluidInterfacePattern
{
    public class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}