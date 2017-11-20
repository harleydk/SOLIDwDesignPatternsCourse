#define CONTRACTS_FULL

using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace LiskovSubstitution_CodeContracts
{
    [ContractClass(typeof(IVoltageAlarm))]
    public abstract class VoltageAlarmBase : IVoltageAlarm
    {
        public int NumberOfAlarmsRaised { get; private set; }

        public double VoltageAlarmThreshold { get; private set; }

        public VoltageAlarmBase(double alarmVoltageThreshold)
        {
            Contract.Requires<ArgumentException>(alarmVoltageThreshold > 0, "alarmVoltageThreshold must be > 0");

            NumberOfAlarmsRaised = 0;
            VoltageAlarmThreshold = alarmVoltageThreshold;

            Contract.Ensures(NumberOfAlarmsRaised == 0, "NumberOfAlarmsRaised must be 0");
        }

        [ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            Contract.Invariant(this.NumberOfAlarmsRaised >= 0);
            Contract.Invariant(this.VoltageAlarmThreshold > 0);
        }

        public virtual bool HasVoltageDroppedBelowThreshold(double currentVoltageLevel)
        {
            Contract.Requires<ArgumentException>(currentVoltageLevel > 0, "currentVoltageLevel must be > 0");

            bool hasVoltageDroppedBelowThreshold = currentVoltageLevel < VoltageAlarmThreshold;
            return hasVoltageDroppedBelowThreshold;
        }

        public void RaiseAlarm()
        {
            NumberOfAlarmsRaised += 1;
            Debug.WriteLine($"Alarm raised {NumberOfAlarmsRaised} times.");

            Contract.Ensures(NumberOfAlarmsRaised > 0, "NumberOfAlarmsRaised must be > 0");
        }
    }
}