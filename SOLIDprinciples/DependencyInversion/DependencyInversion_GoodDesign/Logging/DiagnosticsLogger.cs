using System.Diagnostics;

namespace DependencyInversion_GoodDesign
{
    /// <summary>
    /// Used in the TemperatereSensorLogger class.
    /// </summary>
    public class DiagnosticsLogger
    {
        public void WriteToLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}