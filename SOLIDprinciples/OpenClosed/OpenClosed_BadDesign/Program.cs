using OpenClosed_GoodDesign.HitPointModifiers;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    /// <summary>
    /// The Open/Closed Principle states that a component should be closed for modification, but open for extensions. In the below, 
    /// a <see cref="MagicSword" /> is instantiated with a number of <see cref="HitPointModifierBase"/> variants, which is good practice according 
    /// to the dependency inversion principle - but in the class' <see cref="MagicSword.GetTotalModifierValue(int)"/>-method, we superficially
    /// test on the type of variant, which breaks with the open/closed principle.
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