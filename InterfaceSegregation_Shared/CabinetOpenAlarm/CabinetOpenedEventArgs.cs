using System;

namespace InterfaceSegregation
{
    public sealed class CabinetOpenedEventArgs : EventArgs
    {
        public DateTime CabinetOpenTime;
    }
}