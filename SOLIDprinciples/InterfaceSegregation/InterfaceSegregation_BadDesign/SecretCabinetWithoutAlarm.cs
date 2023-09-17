using System;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// This class honors the full <see cref="ISecretCabinet"/>-contract - but it doesn't need to, and thus breaks
    /// with the interface-segregation principle - i.e. that we should not be having to implement a contract
    /// we don't fully need.
    /// </summary>
    public sealed class SecretCabinetWithoutAlarm : ISecretCabinet
    {
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;
    
        public CabinetOperationResult FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
            return CabinetOperationResult.PresumedSucceeded;
        }

        public CabinetOperationResult RaiseCabinetOpenAlarm()
        {
            throw new ArgumentException("Interface segregation violation");
        }
    }
}