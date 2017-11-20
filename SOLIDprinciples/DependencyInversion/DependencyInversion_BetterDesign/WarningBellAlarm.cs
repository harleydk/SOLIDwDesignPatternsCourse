namespace DependencyInversion_BetterDesign
{
    public sealed class WarningBellAlarm : IAlarm
    {
        public void RaiseAlarm()
        {
            // we'll just pretend to raise an alarm here.
        }
    }
}