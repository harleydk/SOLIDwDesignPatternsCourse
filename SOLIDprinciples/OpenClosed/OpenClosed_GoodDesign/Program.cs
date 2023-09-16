using OpenClosed_GoodDesign.HitPointModifiers;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
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
            double totalModifierValue = magicSword.GetTotalModifierValue(hitPoints);
            Debug.WriteLine($"{nameof(totalModifierValue)} across all {nameof(hitPointModifiers)} is {totalModifierValue}");
        }
    }
}