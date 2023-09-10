using System.IO;

namespace SingleResponsibility_GoodDesign
{
    public sealed class FileLogger
    {
        public void WriteToLog(string logMessage)
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, logMessage);
        }
    }
}