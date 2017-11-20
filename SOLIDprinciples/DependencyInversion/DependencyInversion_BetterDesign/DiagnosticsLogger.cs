using System.Diagnostics;

namespace DependencyInversion_BetterDesign
{
    public sealed class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}