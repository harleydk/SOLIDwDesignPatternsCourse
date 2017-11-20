using System;

namespace InterfaceSegregation_BadDesign
{
    public class SensorEventArgs : EventArgs
    {
        public string SensorId;
        public string SensorValue;
    }
}