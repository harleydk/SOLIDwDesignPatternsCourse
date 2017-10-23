using System;

namespace InterfaceSegregation_BetterDesign
{
    public sealed class CabinetOpenedEventArgs : EventArgs
    {
        public string CabinetOpenedByUserName;
    }
}