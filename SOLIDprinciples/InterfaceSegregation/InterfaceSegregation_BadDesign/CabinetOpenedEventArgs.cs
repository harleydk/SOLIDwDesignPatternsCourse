using System;

namespace InterfaceSegregation_BadDesign
{
    public sealed class CabinetOpenedEventArgs : EventArgs
    {
        public string CabinetOpenedByUserName;
    }
}