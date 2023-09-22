namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class IntimidationHitPointModifier(int modifierValue, int abilityBonus) : HitPointModifierBase(modifierValue, abilityBonus)
    {
        private const int INTIMIDATION_FORCE = 3;

        public int GetIntimidationForce()
        {
            return INTIMIDATION_FORCE;
        }
    }
}
