

namespace DependencyInversion_GoodDesign.Configuration
{
    public class SensorConfiguration
    {
        public SensorType SensorType { get; set; }
        public string SensorId { get; set; }
        public AlarmConfiguration[] Alarms { get; set; }
    }


    public class AlarmConfiguration
    {
        public AlarmType AlarmType { get; set; }
    }
}