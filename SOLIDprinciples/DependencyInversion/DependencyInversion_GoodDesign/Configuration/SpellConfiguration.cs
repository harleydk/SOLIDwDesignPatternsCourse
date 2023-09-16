

namespace DependencyInversion_GoodDesign.Configuration
{
    public class SpellConfiguration
    {
        public SpellType SpellType { get; set; }
        public string SpellId { get; set; }
        public AlarmConfiguration[] Alarms { get; set; }
    }


    public class AlarmConfiguration
    {
        public AlarmType AlarmType { get; set; }
    }
}