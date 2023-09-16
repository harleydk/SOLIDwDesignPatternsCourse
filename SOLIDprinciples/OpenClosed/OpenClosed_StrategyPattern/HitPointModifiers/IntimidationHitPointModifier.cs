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

        public override double CalculateModifierValue(int hitPointValue)
        {
            double modifierValue = base.CalculateModifierValue(hitPointValue);
            double calculatedModifierValue = _intimidationForceStrategy.GetIntimidationForce() + modifierValue;
            return calculatedModifierValue;
        }
    }
}

