using System.Diagnostics;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    /// <summary>
    /// In this <see cref="HitAlarmBase"/> abstract class we encompass the range of functionality of all the 
    /// implementations of the <seealso cref="IArmorHitAlarm"/> interface. 
    /// </summary>
    public abstract class HitAlarmBase : IArmorHitAlarm
    {
        private readonly int _numberOfAlarmRepetitions = 3;
        private readonly int _armorAlarmThreshold;
        private int _numberOfAlarmsRaised = 0;

        public HitAlarmBase(int numberOfAlarmRepetitions, int alarmThreshold)
        {
            _numberOfAlarmRepetitions = numberOfAlarmRepetitions;
            _armorAlarmThreshold = alarmThreshold;
        }

        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            bool alarmIsOverridden = HasArmorDroppedBelowThresholdOverride() is true;
            if (alarmIsOverridden)
            {
                return true;
            }
            else
            {
                bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < _armorAlarmThreshold;
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
            for (int i = 0; i < _numberOfAlarmRepetitions; i++)
            {
                _numberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {_numberOfAlarmsRaised} times.");
            }

            return AlarmRaiseStatus.AlarmPresumedRaised;
        }
    }
}