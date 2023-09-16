using System;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class SecretCabinetWithoutAlarm : ICabinetOpening
    {
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public void FireCabinetOpenedEvent()
        {
            CabinetOpenedEventArgs cabinetOpenedEventArgs = new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow };
            CabinetOpenedEvent.Invoke(this, cabinetOpenedEventArgs);
        }
    }
}