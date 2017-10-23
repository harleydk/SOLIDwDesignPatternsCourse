using System;
using System.Diagnostics.Contracts;

namespace LiskovSubstitution_CodeContracts
{
    public sealed class NewVoltageAlarm : VoltageAlarmBase
    {
        public NewVoltageAlarm(double alarmMinimumVoltageValue) : base(alarmMinimumVoltageValue)
        {
        }

        public override bool HasVoltageDroppedBelowThreshold(double currentVoltageLevel)
        {
            Contract.Requires<ArgumentException>(currentVoltageLevel > 5, "currentVoltageLevel must be > 5"); // this will throw a error on compilation - because it breaks with the Liskov substitution principle.

            bool hasVoltageDroppedBelowThreshold = currentVoltageLevel < VoltageAlarmThreshold;
            return hasVoltageDroppedBelowThreshold;
        }
    }
}