using System.Diagnostics;

namespace DependencyInversion
{
    /// <summary>
    /// A logger that writes to the debug-window
    /// </summary>
    public sealed class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}