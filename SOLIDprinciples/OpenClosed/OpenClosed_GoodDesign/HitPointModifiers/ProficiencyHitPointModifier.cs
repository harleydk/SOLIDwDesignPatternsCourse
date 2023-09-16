namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class ProficiencyHitPointModifier : HitPointModifierBase
    {
        private readonly ProficiencyLevel _proficiencyLevel;

        public ProficiencyHitPointModifier(int modifierValue, int abilityBonus, ProficiencyLevel proficiencyLevel) :
            base(modifierValue, abilityBonus)
        {
            _proficiencyLevel = proficiencyLevel;
        }

        public override double CalculateModifierValue(int hitPointValue)
        {
            double modifierValue = base.CalculateModifierValue(hitPointValue);
            double calculatedModifierValue = modifierValue + EvaluateProficiencyLevel();
            return calculatedModifierValue;
        }

        public int EvaluateProficiencyLevel()
        {
            return (int)_proficiencyLevel;
        }
    }

    public enum ProficiencyLevel
    {
        Novice = 1,
        Guardian = 5,
        Legend = 15
    }

}