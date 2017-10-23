using System;

namespace InterfaceSegregation_AdapterPattern
{
    public interface ISensor
    {
        string SensorId { get; set; }
        string SensorValue { get; set; }
    }
}