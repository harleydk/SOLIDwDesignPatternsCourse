namespace InterfaceSegregation_GoodDesign
{
    // All cabinet-alarm related contract-definitions are moved to a specific interface
    public interface ICabinetAlarming
    {
        void RaiseCabinetOpenAlarm();
    }
}