using System;

namespace InterfaceSegregation_BadDesign
{
    public interface ISecretCabinet
    {
        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;
     
        void RaiseCabinetOpenAlarm();

        void FireCabinetOpenedEvent();
    }
}