using System;

namespace InterfaceSegregation_GoodDesign
{
    public interface ISensor
    {
        string SensorId { get; set; }
        string SensorValue { get; set; }
    }
}