using System;

namespace InterfaceSegregation_BetterDesign
{
    public class SensorEventArgs : EventArgs
    {
        public string SensorId;
        public string SensorValue;
    }
}