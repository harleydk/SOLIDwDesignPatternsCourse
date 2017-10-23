using System;

namespace InterfaceSegregation_AdapterPattern
{
    public class SensorEventArgs : EventArgs
    {
        public string SensorId;
        public string SensorValue;
    }
}