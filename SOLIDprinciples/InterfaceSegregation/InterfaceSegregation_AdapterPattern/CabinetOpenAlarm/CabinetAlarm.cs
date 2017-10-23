using System.Diagnostics;

namespace InterfaceSegregation_AdapterPattern
{
    public sealed class CabinetAlarm
    {
        public void RaiseCabinetAlarm()
        {
            Debug.WriteLine("Raising the alarm, making lots of noise");
        }

        public void ResetCabinetAlarm()
        {
            Debug.WriteLine("That's enough noise, will reset the alarm now.");
        }
    }
}