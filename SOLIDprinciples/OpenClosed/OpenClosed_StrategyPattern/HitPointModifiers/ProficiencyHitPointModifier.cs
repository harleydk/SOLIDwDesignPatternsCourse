namespace OpenClosed_StrategyPattern.HitPointModifiers
{
    public sealed class ProficiencyHitPointModifier(int modifierValue, int abilityBonus, ProficiencyLevel proficiencyLevel) : HitPointModifierBase(modifierValue, abilityBonus)
    {
        public override int CalculateModifier(int hitPointValue)
        {
            int modifierValue = base.CalculateModifier(hitPointValue);
            int calculatedModifierValue = modifierValue + EvaluateProficiencyLevel();
            return calculatedModifierValue;
        }

        public int EvaluateProficiencyLevel()
        {
            return (int)proficiencyLevel;
        }
    }

    public enum ProficiencyLevel
    {
        Novice = 1,
        Guardian = 5,
        Legend = 15
    }

}