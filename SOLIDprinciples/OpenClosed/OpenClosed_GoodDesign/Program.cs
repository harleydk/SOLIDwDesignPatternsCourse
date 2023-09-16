using OpenClosed_BadDesign.PressureSensorImplementations;
using System.Diagnostics;

namespace OpenClosed_BadDesign
{
    /// <summary>
    /// The Open/Closed Principle states that a component should be closed for modification, but open for extensions. In the below, 
    /// a PressureSensorReader 'news up' a number of sensors - wherefore we would need open it up in case we need to modify it.
    /// </summary>
    public sealed class Program
    {
        public static void Main()
        {
            HitPointModifier[] hitPointModifiers = 
            {
                new ProficiencyHitPointModifier(modifierValue: 4, abilityBonus: 1),
                new ProficiencyHitPointModifier(modifierValue: 7, abilityBonus: 1),
                new IntimidationHitPointModifier( modifierValue: 10, abilityBonus: 1)
            };
            MagicSword magicSword = new(hitPointModifiers);

            int hitPoints = 16;
            double averageModifierValue = magicSword.GetAverageModifierValue(hitPoints);
            Debug.WriteLine($"{nameof(averageModifierValue)} across all {nameof(hitPointModifiers)} is {averageModifierValue}");
        }
    }
}