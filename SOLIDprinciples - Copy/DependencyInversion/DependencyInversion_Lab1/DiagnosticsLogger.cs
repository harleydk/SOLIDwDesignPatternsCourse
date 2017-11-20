using System.Diagnostics;

namespace DependencyInversion_Lab1
{
    public class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}