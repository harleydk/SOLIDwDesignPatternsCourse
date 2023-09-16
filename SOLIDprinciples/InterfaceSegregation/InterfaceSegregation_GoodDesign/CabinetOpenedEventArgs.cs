using System;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class CabinetOpenedEventArgs : EventArgs
    {
        public DateTime CabinetOpenTime;
    }
}