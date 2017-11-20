using System;
using System.Diagnostics.Contracts;

namespace LiskovSubstitution_CodeContracts
{
    public sealed class VoltageSensor
    {
        private IVoltageAlarm _voltageAlarm;
        private double _currentSensorVoltage;

        public VoltageSensor()
        {
            _voltageAlarm = new StandardVoltageAlarm(3.3d);
        }

        public void ReadCurrentSensorVoltage()
        {
            Random rnd = new Random();
            _currentSensorVoltage = 3 + rnd.NextDouble();

            Contract.Ensures(_currentSensorVoltage > 3, "_currentSensorVoltage must be > 3v");
        }

        public void RaiseAlarmIfVoltageBelowThreshold()
        {
            Contract.Requires(_voltageAlarm != null, "_voltageAlarm must not be null");
            bool hasVoltageDroppedBelowThreshold = _voltageAlarm.HasVoltageDroppedBelowThreshold(_currentSensorVoltage);

            if (hasVoltageDroppedBelowThreshold)
            {
                _voltageAlarm.RaiseAlarm();
                Contract.Invariant(_voltageAlarm.NumberOfAlarmsRaised > 0, "_voltageAlarm.NumberOfAlarmsRaised must be > 0");
            }
        }
    }
}