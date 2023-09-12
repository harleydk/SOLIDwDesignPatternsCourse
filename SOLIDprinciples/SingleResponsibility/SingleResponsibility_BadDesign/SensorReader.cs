using System;
using System.IO;

namespace SingleResponsibility_BadDesign
{
    /* Example 1: Not good - this class has more than one responsibility, and therefore more than one reason to change -
       * could be new requirements about the logging, or a change to the sensor's generation.
       * _Why troublesome_?: "If a class has more than one responsibility, then the responsibilities become coupled.
       * Changes to one responsibility may impair or inhibit the class’ ability to meet the others."
       * This kind of coupling leads to fragile designs that break in unexpected ways when changed."
       */

    public sealed class SensorReader
    {
        public void WriteSensorValueToLog(string sensorValue)
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, sensorValue);
        }

        public string ReadSensorValue()
        {
            string sensorValue = Guid.NewGuid().ToString();
            return sensorValue;
        }
    }
}