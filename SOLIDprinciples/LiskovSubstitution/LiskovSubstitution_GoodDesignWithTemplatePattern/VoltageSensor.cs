using System;

namespace LiskovSubstitution_GoodDesign
{
    public sealed class VoltageSensor
    {
        private IVoltageAlarm _voltageAlarm;
        private double _currentSensorVoltage;

        public VoltageSensor()
        {
            _voltageAlarm = new StandardVoltageAlarm(3.3d); // now truly interchangable w. NewVoltageAlarm.
        }

        public void ReadCurrentSensorVoltage()
        {
            Random rnd = new Random();
            _currentSensorVoltage = 3 + rnd.NextDouble();
        }

        public void RaiseAlarmIfVoltageBelowThreshold()
        {
            bool hasVoltageDroppedBelowThreshold = _voltageAlarm.HasVoltageDroppedBelowThreshold(_currentSensorVoltage); // knows only about the interface. Any IVoltageAlarm is supported.

            if (hasVoltageDroppedBelowThreshold)
            {
                _voltageAlarm.RaiseAlarm();

                /*#
                // glaring violation - hacks a specific path for a known implementation. Also violates OpenClosed-principle.
                if (_voltageAlarm is NewVoltageAlarm)
                {
                    _voltageAlarm.RaiseAlarm();
                    (_voltageAlarm as NewVoltageAlarm).ResetNumberOfAlarmsRaised(); // This is custom for the specific implementation.
                }
                else
                {
                    _voltageAlarm.RaiseAlarm();
                }*/
            }
        }
    }
}