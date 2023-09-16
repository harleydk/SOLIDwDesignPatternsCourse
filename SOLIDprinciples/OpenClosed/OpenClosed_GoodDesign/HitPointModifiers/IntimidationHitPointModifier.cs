namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public sealed class IntimidationHitPointModifier : HitPointModifier
    {
        private const double INTIMIDATION_FORCE = 3;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus) :
               base(modifierValue, abilityBonus)
        {
        }

        public override double CalculateModifierValue(int hitPointValue)
        {
            double modifierValue = base.CalculateModifierValue(hitPointValue);
            double calculatedModifierValue = INTIMIDATION_FORCE * modifierValue;
            return calculatedModifierValue;
        }
    }
}
}
