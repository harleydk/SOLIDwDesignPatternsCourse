using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class MacheteHitAlarm : IArmorHitAlarm
    {
        private const int NUMBER_OF_ALARM_REPETITIONS = 3;

        private int _numberOfAlarmsRaised = 0;
        private readonly int _armorAlarmThreshold;

        public MacheteHitAlarm(int alarmThreshold)
        {
            _armorAlarmThreshold = alarmThreshold;
        }

        public bool HasArmorDroppedBelowThreshold(int currentArmorDefensePoints)
        {
            // Liskov violation - altered pre-condition! This class determ
            // fds
            // afdsa
            // fds
            // dsa
            // fines a hit with a machete will prove deadly!
            // But this breaks the intent of the contract and the other implementations of the IArmorHitAlarm interface.
            return true;
            if (currentArmorDefensePoints <= _armorAlarmThreshold * 2)
            {
                // In effect,  That doesn't square with the 
                // intention of the interface nor the class siblings.
                return true;
            }
            else
            {
                bool hasArmorDefenseDroppedBelowMinimum = currentArmorDefensePoints < _armorAlarmThreshold;
                return hasArmorDefenseDroppedBelowMinimum;
            }
        }

        public void RaiseAlarm()
        {
            // violation - difference in the meaningfulness of the function's implementation. The other interface-implementations don't deal with repetitions.
            for (int i = 0; i < NUMBER_OF_ALARM_REPETITIONS; i++)
            {
                _numberOfAlarmsRaised += 1;
                Debug.WriteLine($"Alarm raised {_numberOfAlarmsRaised} times.");
            }
        }


    }
}