namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier : HitPointModifierBase
    {
        private const int INTIMIDATION_FORCE = 3;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus) :
               base(modifierValue, abilityBonus)
        {
        }

        public override int CalculateModifierValue(int hitPointValue)
        {
            int modifierValue = base.CalculateModifierValue(hitPointValue);
            int calculatedModifierValue = INTIMIDATION_FORCE + modifierValue;
            return calculatedModifierValue;
        }
    }
}

