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
            try
            {
                Debug.WriteLine(logMessage);
            }
            catch (DiagnosticsLoggingException)
            {
                throw;
            }
        }
    }

    [System.Serializable]
    public class DiagnosticsLoggingException : System.Exception
    {
        public DiagnosticsLoggingException() { }
        public DiagnosticsLoggingException(string message) : base(message) { }
        public DiagnosticsLoggingException(string message, System.Exception inner) : base(message, inner) { }
        protected DiagnosticsLoggingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}