using System;

namespace LiskovSubstitution_BadDesign
{
    /// <summary>
    /// The Liskov Substitution Principle states that an object with a certain interface should be replaceable by a different object that implements 
    /// that same interface while retaining all the correctness of the original intent. That means that not only does the interface have to 
    /// have exactly the same types, but the behavior has to remain correct as well.
    /// 
    /// The main issue with breaking the principle comes from unrealized or faulty expectations. We're led to adopt and believe
    /// one kind of behavior, but trust is breached and insecurities arise (and technical debt accrues) when it turns 
    /// out we can't count on what we're been told.
    /// </summary>
    /// <remarks>
    /// Barbara Liskov is an American computer scientist. <see cref="https://en.wikipedia.org/wiki/Barbara_Liskov"/>
    /// </remarks>
    public sealed class Program
    {
        /// <summary>
        /// A <see cref="PlayerArmor"/> subtracts a number of defense-points and raises an <see cref="IArmorHitAlarm"/> if the armor-level
        /// dips below a given threshold. This works well for a standard <see cref="SwordHitAlarm"/> implementation, but a newly introduced
        /// <see cref="MacheteHitAlarm"/> introduces different requirements and thus breaks with the Liskov Substitution principle.
        /// </summary>
        public static void Main()
        {
            PlayerArmor playerArmor = new();

            playerArmor.SetArmorHitAlarm(new SwordHitAlarm(alarmThreshold: 3));
            playerArmor.SubtractDefensePoints(new Random().Next());
            playerArmor.RaiseAlarmIfArmorDefenseBelowThreshold();

            playerArmor.SetArmorHitAlarm(new MacheteHitAlarm(alarmThreshold: 3));
            playerArmor.SubtractDefensePoints(new Random().Next());
            playerArmor.RaiseAlarmIfArmorDefenseBelowThreshold();
        }
    }
}