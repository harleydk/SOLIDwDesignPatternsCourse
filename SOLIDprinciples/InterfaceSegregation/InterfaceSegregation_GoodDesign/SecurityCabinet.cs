using InterfaceSegregation;
using System;
using System.Diagnostics;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// A 'regular' security-cabinet. Includes an alarm. Implements multiple interfaces.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarming"/>
    public class SecurityCabinet : ICabinetOpening, ICabinetAlarming
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