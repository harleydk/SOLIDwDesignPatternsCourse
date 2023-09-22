namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public abstract class HitPointModifierBase(int modifierValue, int abilityBonus) : IHitPointModifier
    {
        protected readonly int _modifierValue = modifierValue;
        protected readonly int _abilityBonus = abilityBonus;

        public virtual int CalculateModifier(int hitPointValue)
        {
            int modifier = _modifierValue + _abilityBonus;
            return modifier;
        }
    }
}
