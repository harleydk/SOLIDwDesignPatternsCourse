using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class SwordHitAlarm(int alarmThreshold) : IArmorHitAlarm
    {
        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < alarmThreshold;
            return hasArmorDefenseDroppedBelowMinimum;
        }

        public AlarmRaiseStatus RaiseAlarm()
        {
            Debug.WriteLine($"{nameof(SwordHitAlarm)} raised.");
            return AlarmRaiseStatus.AlarmPresumedRaised;
        }
    }
}