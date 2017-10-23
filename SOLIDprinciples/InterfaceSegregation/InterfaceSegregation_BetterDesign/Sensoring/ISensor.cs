using System;

namespace InterfaceSegregation_BetterDesign
{
    public interface ISensor
    {
        string SensorId { get; set; }
        string SensorValue { get; set; }
    }
}