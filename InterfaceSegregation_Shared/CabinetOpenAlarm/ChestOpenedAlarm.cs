using System.Diagnostics;

namespace InterfaceSegregation
{
    public sealed class ChestOpenedAlarm
    {
        public void RaiseCabinetAlarm()
        {
            Debug.WriteLine("Raising the alarm, making lots of noise");
        }
    }
}