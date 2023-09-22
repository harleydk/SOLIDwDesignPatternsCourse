using System.Diagnostics;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    /// <summary>
    /// In this <see cref="HitAlarmBase"/> abstract class we encompass the range of functionality of all the 
    /// implementations of the <seealso cref="IArmorHitAlarm"/> interface. 
    /// </summary>
    public abstract class HitAlarmBase(int numberOfAlarmRepetitions, int alarmThreshold) : IArmorHitAlarm
    {
        private int _numberOfAlarmsRaised = 0;

        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            bool alarmIsOverridden = HasArmorDroppedBelowThresholdOverride() is true;
            if (alarmIsOverridden)
            {
                return true;
            }
            else
            {
                bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < alarmThreshold;
                return hasArmorDefenseDroppedBelowMinimum;
            }
        }

        /// <summary>
        /// Template method - the <see cref="MacheteHitAlarm"/> overrides this and thus aligns itself with
        /// the Liskov principle.
        /// </summary>
        /// <returns></returns>
        public virtual bool HasArmorDroppedBelowThresholdOverride()
        {
            return false;
        }

        public AlarmRaiseStatus RaiseAlarm()
        {
            // Liskov violation - difference in the meaningfulness of the function's implementation. The other interface-implementations don't deal with repetitions.
            for (int i = 0; i < numberOfAlarmRepetitions; i++)
            {
                _numberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {_numberOfAlarmsRaised} times.");
            }

            return AlarmRaiseStatus.AlarmPresumedRaised;
        }
    }
}