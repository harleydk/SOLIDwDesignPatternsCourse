namespace OpenClosed_BadDesign.PressureSensorImplementations
{
    public sealed class ProficiencyHitPointModifier : HitPointModifier
    {
        public ProficiencyHitPointModifier(int modifierValue, int abilityBonus) : 
            base(modifierValue, abilityBonus)
        {
        }
    }
}