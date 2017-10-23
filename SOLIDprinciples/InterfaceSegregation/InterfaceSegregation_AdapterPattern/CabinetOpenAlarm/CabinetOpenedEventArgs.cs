using System;

namespace InterfaceSegregation_AdapterPattern
{
    public sealed class CabinetOpenedEventArgs : EventArgs
    {
        public string CabinetOpenedByUserName;
    }
}