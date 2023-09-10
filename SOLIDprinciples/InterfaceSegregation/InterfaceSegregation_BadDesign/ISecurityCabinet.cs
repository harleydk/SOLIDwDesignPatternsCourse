using InterfaceSegregation;
using System;
using System.Collections.Generic;

namespace InterfaceSegregation_BadDesign
{
    /// <summary>
    /// The contract that all implementing security-cabinets must honor.
    /// </summary>
    public interface ISecurityCabinet
    {
        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;
     
        void RaiseCabinetOpenAlarm();

        void FireCabinetOpenedEvent();
    }
}