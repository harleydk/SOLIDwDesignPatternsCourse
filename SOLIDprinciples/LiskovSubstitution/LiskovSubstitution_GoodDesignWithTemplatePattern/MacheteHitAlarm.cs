using System;
using System.Diagnostics;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public sealed class MacheteHitAlarm(int alarmThreshold) : HitAlarmBase(numberOfAlarmRepetitions: 3, alarmThreshold)
    {
       
        public override bool HasArmorDroppedBelowThresholdOverride()
        {
            bool isNight = DateTime.UtcNow.TimeOfDay.Hours > 22 && DateTime.UtcNow.TimeOfDay.Hours < 6;
            return isNight;
        }
    }
}