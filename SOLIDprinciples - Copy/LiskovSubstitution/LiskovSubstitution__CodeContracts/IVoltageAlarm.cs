using System.Diagnostics.Contracts;

namespace LiskovSubstitution_CodeContracts
{
    [ContractClass(typeof(VoltageAlarmBase))]
    public interface IVoltageAlarm
    {
        int NumberOfAlarmsRaised { get; }

        double VoltageAlarmThreshold { get; }

        bool HasVoltageDroppedBelowThreshold(double voltageLevel);

        void RaiseAlarm();
    }
}