using System;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// A 'regular' secret cabinet. Includes an alarm. Implements multiple interfaces.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarming"/>
    public class SecretCabinet : ICabinetOpening, ICabinetAlarming
    {
        private readonly CabinetAlarm _cabinetAlarm;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public SecretCabinet(CabinetAlarm cabinetAlarm)
        {
            _cabinetAlarm = cabinetAlarm;
        }

        public void FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
        }

        public void RaiseCabinetOpenAlarm()
        {
            _cabinetAlarm.RaiseCabinetAlarm();
        }
    }
}