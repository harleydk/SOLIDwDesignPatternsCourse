﻿using System.IO;

namespace SingleResponsibility_BetterDesign
{
    public sealed class FileLogger
    {
        public void WriteToLog(string logMessage)
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, logMessage);
        }
    }
}