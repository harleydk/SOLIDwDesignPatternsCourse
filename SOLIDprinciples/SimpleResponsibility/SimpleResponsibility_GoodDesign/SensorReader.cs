using System;

namespace SingleResponsibility_BetterDesign
{
    public sealed class SensorReader
    {
        public string ReadSensorValue()
        {
            string sensorValue = Guid.NewGuid().ToString();
            return sensorValue;
        }
    }
}