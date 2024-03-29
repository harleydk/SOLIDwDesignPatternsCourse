﻿using System;

namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    /// <summary>
    /// The Liskov Substitution principle, in comparison to the other principles in the SOLID acronym, doesn't lend 
    /// itself well to code-smells detection. Best we can do is to foster the discipline and weed it out as we see it.
    /// In the <see cref="HitAlarmBase"/>-class we've encompassed the combined functionality of the <seealso cref="IArmorHitAlarm"/> 
    /// implementations. In this way we can ensure the different implementations are substitutable with each other.
    /// </summary>
    /// <seealso cref="https://deviq.com/principles/liskov-substitution-principle"/> - great phone-realization of the principle.
    public sealed class Program
    {
        public static void Main()
        {
            PlayerArmor playerArmor = new(armorDefensePoints: 100);

            HitAlarmBase swordHitAlarm = new SwordHitAlarm(alarmThreshold: 3);
            _ = playerArmor.SetArmorHitAlarm(swordHitAlarm);
            _ = playerArmor.SubtractDefensePoints(new Random().Next());
            _ = playerArmor.RaiseAlarmIfArmorDefenseBelowThreshold();

            HitAlarmBase macheteHitAlarm = new MacheteHitAlarm(alarmThreshold: 6);
            _ = playerArmor.SetArmorHitAlarm(macheteHitAlarm);
            _ = playerArmor.SubtractDefensePoints(new Random().Next());
            _ = playerArmor.RaiseAlarmIfArmorDefenseBelowThreshold();
        }
    }
}