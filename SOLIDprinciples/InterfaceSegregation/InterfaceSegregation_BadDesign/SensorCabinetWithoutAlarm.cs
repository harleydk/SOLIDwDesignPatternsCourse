using InterfaceSegregation;
using System;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// This class honors the full ISensorCabinet-contract - but it doesn't need to, and thus breaks
    /// with the interface-segregation principle - i.e. that we should not be having to implement a contract
    /// we don't fully need.
    /// </summary>
    public sealed class SensorCabinetWithoutAlarm : ISecurityCabinet
    {
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;
    
        public void FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
        }

        public void RaiseCabinetOpenAlarm()
        {
            throw new NotImplementedException("Interface segregation violation");
        }
    }
}