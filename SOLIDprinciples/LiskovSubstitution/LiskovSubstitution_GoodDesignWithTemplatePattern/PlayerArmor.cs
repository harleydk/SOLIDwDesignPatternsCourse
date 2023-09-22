namespace LiskovSubstitution_GoodDesignWithTemplatePattern
{
    public sealed class PlayerArmor(int armorDefensePoints)
    {
        private IArmorHitAlarm _armorHitAlarm;

        public PlayerArmorOperationResult SetArmorHitAlarm(IArmorHitAlarm armorHitAlarm)
        {
            _armorHitAlarm = armorHitAlarm;
            return PlayerArmorOperationResult.PresumedSucceeded;
        }

        public PlayerArmorOperationResult SubtractDefensePoints(int defensePointsToSubtract)
        {
            armorDefensePoints -= defensePointsToSubtract;
            return PlayerArmorOperationResult.PresumedSucceeded;
        }

        public PlayerArmorOperationResult RaiseAlarmIfArmorDefenseBelowThreshold()
        {
            bool hasVoltageDroppedBelowAcceptableLevel = _armorHitAlarm.HasArmorDroppedBelowThreshold(armorDefensePoints); // knows only about the interface. Any IArmorHitAlarm is supported.
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