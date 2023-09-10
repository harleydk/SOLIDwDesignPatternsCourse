using InterfaceSegregation;
using System;

namespace InterfaceSegregation_GoodDesign
{
    // All cabinet-open related contract-definitions are moved to a specific interface
    public interface ICabinetOpening
    {
        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        void FireCabinetOpenedEvent();
    
    }
}