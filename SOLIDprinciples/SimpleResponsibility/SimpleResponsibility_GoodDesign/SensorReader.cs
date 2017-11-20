using System;

namespace SingleResponsibility_GoodDesign
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