using System.Diagnostics;

namespace InterfaceSegregation_GoodDesign
{
    public sealed class CabinetAlarm
        {
            public void RaiseCabinetAlarm()
            {
                Debug.WriteLine("Raising the alarm, making lots of noise");
            }
        }
}