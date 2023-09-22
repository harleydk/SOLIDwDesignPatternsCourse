using System;
using System.Diagnostics;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// A 'regular' secret cabinet. Includes an alarm, that fires when the <see cref="CabinetOpenedEvent"/> 
    /// </summary>
    public class SecretCabinet(CabinetAlarm cabinetAlarm) : ISecretCabinet
    {
      
        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public CabinetOperationResult FireCabinetOpenedEvent()
        {
            CabinetOpenedEvent?.Invoke(this, new CabinetOpenedEventArgs { CabinetOpenTime = DateTime.UtcNow });
            return CabinetOperationResult.PresumedSucceeded;
        }

        public CabinetOperationResult RaiseCabinetOpenAlarm()
        {
            cabinetAlarm.RaiseCabinetAlarm();
            return CabinetOperationResult.PresumedSucceeded;
        }
    }
}