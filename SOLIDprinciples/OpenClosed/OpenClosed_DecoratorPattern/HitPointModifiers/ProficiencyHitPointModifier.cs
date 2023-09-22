using System.Diagnostics;

namespace OpenClosed_GoodDesign.HitPointModifiers
{
    public sealed class ProficiencyHitPointModifier : HitPointModifierDecorator
    {
        private readonly ProficiencyLevel _proficiencyLevel;

        public ProficiencyHitPointModifier(int modifierValue, int abilityBonus, ProficiencyLevel proficiencyLevel, IHitPointModifier hitPointModifier) :
            base(modifierValue, abilityBonus, hitPointModifier)
        {
            _proficiencyLevel = proficiencyLevel;
        }

        public override int CalculateModifier(int hitPointValue)
        {
            int modifierValue = base.CalculateModifier(hitPointValue);
            Debug.WriteLine($"Returning {modifierValue} from a {base.GetType().Name}. Will be added.");
            int proficiencyLevel = EvaluateProficiencyLevel();
            int calculatedModifierValue = proficiencyLevel + modifierValue;
            Debug.WriteLine($"When adding the {nameof(proficiencyLevel)} of {proficiencyLevel} we return {calculatedModifierValue}.");
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