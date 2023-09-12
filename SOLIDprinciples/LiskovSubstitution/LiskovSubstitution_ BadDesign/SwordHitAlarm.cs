using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class SwordHitAlarm : IArmorHitAlarm
    {
        private readonly int _armorAlarmThreshold;

        public SwordHitAlarm(int alarmThreshold)
        {
            _armorAlarmThreshold = alarmThreshold;
        }

        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < _armorAlarmThreshold;
            return hasArmorDefenseDroppedBelowMinimum;
        }

        public void RaiseAlarm()
        {
            Debug.WriteLine($"{nameof(SwordHitAlarm)} raised.");
        }
    }
}