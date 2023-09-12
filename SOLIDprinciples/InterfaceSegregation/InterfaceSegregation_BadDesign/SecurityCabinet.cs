using InterfaceSegregation;
using System;
using System.Diagnostics;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// A 'regular' security-cabinet. Includes an alarm, that fires when the <see cref="CabinetOpenedEvent"/> 
    /// </summary>
    public class SecurityCabinet : ISecurityCabinet
    {
        private readonly CabinetAlarm _cabinetAlarm;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public SecurityCabinet(CabinetAlarm cabinetAlarm)
        {
            _cabinetAlarm = cabinetAlarm;
        }

        public void FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
        }

        public void RaiseCabinetOpenAlarm()
        {
            Debug.Assert(_cabinetAlarm != null, "Cabinet alarm not initialized");
            _cabinetAlarm.RaiseCabinetAlarm();
        }
    }
}