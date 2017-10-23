using System;

namespace InterfaceSegregation_GoodDesign
{
    public class SensorEventArgs : EventArgs
    {
        public string SensorId;
        public string SensorValue;
    }
}