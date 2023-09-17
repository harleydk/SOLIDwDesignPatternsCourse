using System;

namespace InterfaceSegregation_BadDesign
{
    public interface ISecretCabinet
    {
        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        CabinetOperationResult RaiseCabinetOpenAlarm();

        CabinetOperationResult FireCabinetOpenedEvent();
    }

    public enum CabinetOperationResult
    {
        Succeeded,
        Failed,
        PresumedSucceeded
    }
}