namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public sealed class PlayerArmor
    {
        private IArmorHitAlarm _armorHitAlarm;
        private int _currentArmorDefensePoints;

        public PlayerArmor(int initialArmorDefensePoints)
        {
            _currentArmorDefensePoints = initialArmorDefensePoints;
        }

        public PlayerArmorOperationResult SetArmorHitAlarm(IArmorHitAlarm armorHitAlarm)
        {
            _armorHitAlarm = armorHitAlarm;
            return PlayerArmorOperationResult.PresumedSucceeded;
        }

        public PlayerArmorOperationResult SubtractDefensePoints(int defensePointsToSubtract)
        {
            _currentArmorDefensePoints -= defensePointsToSubtract;
            return PlayerArmorOperationResult.PresumedSucceeded;
        }

        public PlayerArmorOperationResult RaiseAlarmIfArmorDefenseBelowThreshold()
        {
            bool hasVoltageDroppedBelowAcceptableLevel = _armorHitAlarm.HasArmorDroppedBelowThreshold(_currentArmorDefensePoints); // knows only about the interface. Any IArmorHitAlarm is supported.
            if (hasVoltageDroppedBelowAcceptableLevel)
            {
                _armorHitAlarm.RaiseAlarm();
            }

            return PlayerArmorOperationResult.PresumedSucceeded;
        }
    }

    public enum PlayerArmorOperationResult
    {
        Succeeded,
        Failed,
        PresumedSucceeded
    }
}