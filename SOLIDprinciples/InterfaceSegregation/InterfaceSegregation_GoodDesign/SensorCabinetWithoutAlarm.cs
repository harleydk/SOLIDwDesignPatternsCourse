using InterfaceSegregation;
using System;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class SensorCabinetWithoutAlarm : ICabinetOpening
    {
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public void FireCabinetOpenedEvent()
        {
            CabinetOpenedEventArgs cabinetOpenedEventArgs = new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow };
            CabinetOpenedEvent.Invoke(this, cabinetOpenedEventArgs);
        }
    }
}