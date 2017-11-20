using System.Diagnostics;

namespace DependencyInversion_BadDesign
{
    public sealed class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}