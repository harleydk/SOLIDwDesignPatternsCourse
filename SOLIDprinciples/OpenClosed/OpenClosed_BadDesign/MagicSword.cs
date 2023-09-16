using OpenClosed_GoodDesign.HitPointModifiers;

namespace OpenClosed_GoodDesign
{
    public sealed class MagicSword
    {
        private readonly HitPointModifierBase[] _hitPointModifiers;

        public MagicSword(HitPointModifierBase[] hitPointModifiers)
        {
            _hitPointModifiers = hitPointModifiers;
        }

        /// <summary>
        /// Gets the modifier values across all <see cref="HitPointModifierBase"/>s.
        /// </summary>
        /// <remarks>
        /// <i>This method breaks with the open/closed principle, in that we calculate the result in consideration 
        /// to a specific <see cref="HitPointModifierBase"/>-type. So if we introduce a new type of <see cref="HitPointModifierBase"/>, we must now 
        /// modify this method accordingly.</i>
        /// </remarks>
        public int GetTotalModifierValue(int hitPointValue)
        {
            int totalModifyValue = 0;
            foreach (HitPointModifierBase hitPointModifier in _hitPointModifiers)
            {
                if (hitPointModifier is ProficiencyHitPointModifier)
                {
                    int calculateModifierValue(int hitPointValue)
                    {
                        int modifierValue = hitPointModifier.CalculateModifierValue(hitPointValue);
                        int proficiencyLevel = ((ProficiencyHitPointModifier)hitPointModifier).EvaluateProficiencyLevel();
                        int calculatedModifierValue = proficiencyLevel + modifierValue;
                        return calculatedModifierValue;
                    }

                    totalModifyValue += calculateModifierValue(hitPointValue);
                }
                else if (hitPointModifier is IntimidationHitPointModifier)
                {
                    int calculateModifierValue(int hitPointValue)
                    {
                        int modifierValue = hitPointModifier.CalculateModifierValue(hitPointValue);
                        int intimidationForce = ((IntimidationHitPointModifier)hitPointModifier).GetIntimidationForce();
                        int calculatedModifierValue = intimidationForce + modifierValue;
                        return calculatedModifierValue;
                    }
                    totalModifyValue += calculateModifierValue(hitPointValue);
                }
            }

            return totalModifyValue;
        }
    }
}