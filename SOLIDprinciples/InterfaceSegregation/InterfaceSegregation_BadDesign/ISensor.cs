using System;

namespace InterfaceSegregation_BadDesign
{
    public interface ISensor
    {
        string SensorId { get; set; }
        string SensorValue { get; set; }
    }
}