namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier : HitPointModifierBase
    {
        private const double INTIMIDATION_FORCE = 3;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus) :
               base(modifierValue, abilityBonus)
        {
        }

        public override double CalculateModifierValue(int hitPointValue)
        {
            double modifierValue = base.CalculateModifierValue(hitPointValue);
            double calculatedModifierValue = INTIMIDATION_FORCE + modifierValue;
            return calculatedModifierValue;
        }
    }
}

