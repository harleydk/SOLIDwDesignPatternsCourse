using OpenClosed_StrategyPattern.IntimidationStrategies;

namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier(int modifierValue, int abilityBonus, IIntimidationForceStrategy intimidationForceStrategy) : HitPointModifierBase(modifierValue, abilityBonus)
    {
              public override int CalculateModifier(int hitPointValue)
        {
            int modifierValue = base.CalculateModifier(hitPointValue);
            int calculatedModifierValue = intimidationForceStrategy.GetIntimidationForce() + modifierValue;
            return calculatedModifierValue;
        }
    }
}

