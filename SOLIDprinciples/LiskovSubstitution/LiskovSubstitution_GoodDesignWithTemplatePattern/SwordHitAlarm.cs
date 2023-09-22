using System;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public sealed class SwordHitAlarm (int alarmThreshold) : HitAlarmBase(numberOfAlarmRepetitions: 0, alarmThreshold)
    {
    }
}