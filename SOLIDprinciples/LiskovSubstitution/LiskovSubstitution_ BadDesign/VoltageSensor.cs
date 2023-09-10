using System;
using System.Diagnostics;

namespace LiskovSubstitution_BadDesign
{
    public sealed class VoltageSensor
    {
        private IVoltageAlarm _voltageAlarm;
        private double _currentSensorVoltage;

        public double CurrentSensorVoltage { get => _currentSensorVoltage; set => _currentSensorVoltage = value; }

        public VoltageSensor()
        {
        }

        public void SetVoltageAlarm(IVoltageAlarm alarm)
        {
            _voltageAlarm = alarm;
        }

        public void ReadCurrentSensorVoltage()
        {
            Random someRandomFakeSensorVoltage = new();
            _currentSensorVoltage = 3 + someRandomFakeSensorVoltage.NextDouble();
        }

        public void RaiseAlarmIfVoltageBelowMinimum()
        {
            Debug.Assert(_voltageAlarm != null, "Voltage-alarm should be initialized at this point.");
            bool hasVoltageDroppedBelowAcceptableLevel = _voltageAlarm.HasVoltageDroppedBelowThreshold(_currentSensorVoltage); // knows only about the interface. Any IVoltageAlarm is supported.

            if (hasVoltageDroppedBelowAcceptableLevel)
            {
                // glaring violation - hacks a specific path for a known implementation. Also violates OpenClosed-principle, we would have to update code with new alarm-implementations.
                if (_voltageAlarm is NewVoltageAlarm)
                {
                    _voltageAlarm.RaiseAlarm();
                    (_voltageAlarm as NewVoltageAlarm).ResetNumberOfAlarmsRaised(); // This is custom for the specific implementation.
                }
                else
                {
                    _voltageAlarm.RaiseAlarm();
                }
            }
        }
    }
}