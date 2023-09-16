using OpenClosed_BadDesign.PressureSensorImplementations;

namespace OpenClosed_BadDesign
{
    public sealed class MagicSword
    {
        private readonly HitPointModifier[] _hitPointModifiers;

        public MagicSword(HitPointModifier[] hitPointModifiers)
        {
            _hitPointModifiers = hitPointModifiers;
        }

        /// <summary>
        /// Gets the average modifier values across all <see cref="HitPointModifier"/>s.
        /// </summary>
        /// <remarks>
        /// <i>This method breaks with the open/closed principle, in that we calculate the result in consideration 
        /// to a specific <see cref="HitPointModifier"/>-type. So if we introduce a new type of <see cref="HitPointModifier"/>, we must now 
        /// modify this method accordingly.</i>
        /// </remarks>
        public double GetAverageModifierValue(int hitPointValue)
        {
            double totalModifyValue = 0;
            foreach (HitPointModifier hitPointModifier in _hitPointModifiers)
            {
                if (hitPointModifier is ProficiencyHitPointModifier)
                {
                    totalModifyValue += hitPointModifier.CalculateModifierValue(hitPointValue);
                }
                else if (hitPointModifier is IntimidationHitPointModifier)
                {
                    double calculateModifierValue(int hitPointValue)
                    {
                        double modifierValue = hitPointModifier.CalculateModifierValue(hitPointValue);
                        double intimidationForce = ((IntimidationHitPointModifier)hitPointModifier).GetIntimidationForce();
                        double calculatedModifierValue = intimidationForce * modifierValue;
                        return calculatedModifierValue;
                    }
                    totalModifyValue += calculateModifierValue(hitPointValue);
                }
            }

            double averageModifyValue = totalModifyValue / _hitPointModifiers.Length;
            return averageModifyValue;
        }
    }
}