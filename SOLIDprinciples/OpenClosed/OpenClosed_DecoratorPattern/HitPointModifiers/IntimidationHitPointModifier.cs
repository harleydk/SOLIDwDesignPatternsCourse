using System.Diagnostics;

namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier : HitPointModifierDecorator
    {
        private const int INTIMIDATION_FORCE = 3;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus, IHitPointModifier hitPointModifier) :
            base(modifierValue, abilityBonus, hitPointModifier)
        {
        }

        public override int CalculateModifierValue(int hitPointValue)
        {
            int modifierValue = base.CalculateModifierValue(hitPointValue);
            Debug.WriteLine($"Returning {modifierValue} from a {base.GetType().Name}. Will be added.");
            int calculatedModifierValue = INTIMIDATION_FORCE + modifierValue;
            Debug.WriteLine($"When adding the {nameof(INTIMIDATION_FORCE)} of {INTIMIDATION_FORCE} we return {calculatedModifierValue}.");
            return calculatedModifierValue;
        }
    }
}
