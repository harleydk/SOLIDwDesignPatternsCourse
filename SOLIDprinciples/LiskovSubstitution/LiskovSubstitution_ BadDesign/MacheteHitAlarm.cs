using System;
using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class MacheteHitAlarm(int alarmThreshold) : IArmorHitAlarm
    {
        private const int NUMBER_OF_ALARM_REPETITIONS = 3;

        private int _numberOfAlarmsRaised = 0;
       
        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            // Liskov Substitution violation - altered pre-condition! This class breaks the intent of the contract and the other
            // implementations of the IArmorHitAlarm interface.
            bool isNight = DateTime.UtcNow.TimeOfDay.Hours > 22 && DateTime.UtcNow.TimeOfDay.Hours < 6;
            if (isNight)
            {
                return true; // machete hits at night instantly indicates the armor has dropped below the threshold.
            }
            else
            {
                bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < alarmThreshold;
                return hasArmorDefenseDroppedBelowMinimum;
            }
        }

        public AlarmRaiseStatus RaiseAlarm()
        {
            // Liskov Substitution violation - difference in the meaningfulness of the function's implementation. The other
            // interface-implementations don't deal with 'NUMBER_OF_ALARM_REPETITIONS'.
            for (int i = 0; i < NUMBER_OF_ALARM_REPETITIONS; i++)
            {
                _numberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {_numberOfAlarmsRaised} times.");
            }

            return AlarmRaiseStatus.AlarmPresumedRaised;
        }


    }
}