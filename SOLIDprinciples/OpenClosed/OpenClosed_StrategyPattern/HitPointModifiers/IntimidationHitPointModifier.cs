using OpenClosed_StrategyPattern.IntimidationStrategies;

namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier : HitPointModifierBase
    {
        private readonly IIntimidationForceStrategy _intimidationForceStrategy;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus, IIntimidationForceStrategy intimidationForceStrategy) :
               base(modifierValue, abilityBonus)
        {
            _intimidationForceStrategy = intimidationForceStrategy;
        }

        public override int CalculateModifierValue(int hitPointValue)
        {
            int modifierValue = base.CalculateModifierValue(hitPointValue);
            int calculatedModifierValue = _intimidationForceStrategy.GetIntimidationForce() + modifierValue;
            return calculatedModifierValue;
        }
    }
}

