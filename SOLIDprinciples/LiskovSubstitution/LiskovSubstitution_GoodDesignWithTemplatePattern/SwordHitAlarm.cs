using System;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public sealed class SwordHitAlarm : HitAlarmBase
    {
        public SwordHitAlarm(int alarmThreshold) :
            base(numberOfAlarmRepetitions: 0, alarmThreshold)
        {
        }
    }
}