using System;

namespace InterfaceSegregation_GoodDesign
{
    // All cabinet-open-alarm related stuff is moved to its own interface
    public interface ICabinetOpenAlarm
    {
        void RaiseCabinetOpenAlarm();

        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        void FireCabinetOpenedEvent(object sender, CabinetOpenedEventArgs e);

        void ResetCabinetOpenAlarm();

        string GetCabinetLastOpenedByUserId();
    }
}