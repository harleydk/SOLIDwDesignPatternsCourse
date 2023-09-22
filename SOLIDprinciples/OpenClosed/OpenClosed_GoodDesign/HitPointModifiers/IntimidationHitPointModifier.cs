namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier(int modifierValue, int abilityBonus) : HitPointModifierBase(modifierValue, abilityBonus)
    {
        private const int INTIMIDATION_FORCE = 3;

        public override int CalculateModifier(int hitPointValue)
        {
            int modifierValue = base.CalculateModifier(hitPointValue);
            int calculatedModifierValue = INTIMIDATION_FORCE + modifierValue;
            return calculatedModifierValue;
        }
    }
}

