namespace LiskovSubstitution_BadDesign
{
    public sealed class PlayerArmor
    {
        private IArmorHitAlarm _armorHitAlarm;
        private int _currentArmorDefensePoints  = 100;

        public void SetArmorHitAlarm(IArmorHitAlarm armorHitAlarm)
        {
            _armorHitAlarm = armorHitAlarm;
        }

        public void SubtractDefensePoints(int defensePointsToSubtract)
        {
            _currentArmorDefensePoints -= defensePointsToSubtract;
        }

        public void RaiseAlarmIfArmorDefenseBelowThreshold()
        {
            bool hasVoltageDroppedBelowAcceptableLevel = _armorHitAlarm.HasArmorDroppedBelowThreshold(_currentArmorDefensePoints); // knows only about the interface. Any IArmorHitAlarm is supported.
            if (hasVoltageDroppedBelowAcceptableLevel)
            {
                _armorHitAlarm.RaiseAlarm();
            }
        }
    }
}