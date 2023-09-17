using System;

namespace InterfaceSegregation_GoodDesign
{
    /// <summary>
    /// A 'regular' secret cabinet. Includes an alarm. Implements multiple interfaces.
    /// </summary>
    /// <see cref="ICabinetOpening"/>
    /// <seealso cref="ICabinetAlarm"/>
    public class SecretCabinet : ICabinetOpening, ICabinetAlarm
    {
        private readonly CabinetAlarm _cabinetAlarm;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public SecretCabinet(CabinetAlarm cabinetAlarm)
        {
            _cabinetAlarm = cabinetAlarm;
        }

        public CabinetOpeningResult FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
            return CabinetOpeningResult.PresumedOpened;
        }

        public CabinetAlarmResult RaiseCabinetOpenAlarm()
        {
            _cabinetAlarm.RaiseCabinetAlarm();
            return CabinetAlarmResult.AlarmPresumedRaised;
        }
    }
}