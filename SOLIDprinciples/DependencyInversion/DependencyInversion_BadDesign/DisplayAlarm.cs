namespace DependencyInversion_BadDesign
{
    public sealed class DisplayAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            // we'll just pretend to raise an alarm here.
        }
    }
}