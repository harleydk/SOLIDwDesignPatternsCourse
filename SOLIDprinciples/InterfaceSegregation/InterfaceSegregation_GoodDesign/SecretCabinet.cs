using System;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// A 'regular' secret cabinet. Includes an alarm. Implements multiple interfaces.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarm"/>
    public class SecretCabinet(CabinetAlarm cabinetAlarm) : ICabinetOpening, ICabinetAlarm
    {
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public CabinetOpeningResult FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
            return CabinetOpeningResult.PresumedOpened;
        }

        public CabinetAlarmResult RaiseCabinetOpenAlarm()
        {
            cabinetAlarm.RaiseCabinetAlarm();
            return CabinetAlarmResult.AlarmPresumedRaised;
        }
    }
}