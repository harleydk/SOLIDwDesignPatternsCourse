namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public sealed class IntimidationHitPointModifier : HitPointModifier
    {
        private const double INTIMIDATION_FORCE = 3;

        public IntimidationHitPointModifier(int modifierValue, int abilityBonus):
               base(modifierValue, abilityBonus)
        {
        }

        public double GetIntimidationForce()
        {
            return INTIMIDATION_FORCE;
        }
    }
}
