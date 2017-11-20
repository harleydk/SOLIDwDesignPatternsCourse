namespace DependencyInversion_BetterDesign
{
    public sealed class DisplayAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            // we'll just pretend to raise an alarm here.
        }
    }
}