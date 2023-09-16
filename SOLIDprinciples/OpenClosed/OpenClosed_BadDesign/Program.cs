using OpenClosed_GoodDesign.HitPointModifiers;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    /// <summary>
    /// The Open/Closed Principle states that a component should be closed for modification, but open for extensions. In the below, 
    /// a PressureSensorReader 'news up' a number of sensors - wherefore we would need open it up in case we need to modify it.
    /// </summary>
    public sealed class Program
    {
        public static void Main()
        {
            HitPointModifierBase[] hitPointModifiers = 
            {
                new ProficiencyHitPointModifier(modifierValue: 4, abilityBonus: 1, ProficiencyLevel.Guardian),
                new IntimidationHitPointModifier( modifierValue: 10, abilityBonus: 1)
            };
            MagicSword magicSword = new(hitPointModifiers);

            int hitPoints = 16;
            int totalModifierValue = magicSword.GetTotalModifierValue(hitPoints);
            Debug.WriteLine($"{nameof(totalModifierValue)} across all {nameof(hitPointModifiers)} is {totalModifierValue}");
        }
    }
}