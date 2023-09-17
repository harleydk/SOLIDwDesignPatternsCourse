using OpenClosed_GoodDesign.HitPointModifiers;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    /// <summary>
    /// To fulfill the open/closed principle in the <see cref="MagicSword"/> class, specifically in its <seealso cref="MagicSword.GetTotalModifierValue(int)"/>-method,
    /// we ensure that <seealso cref="HitPointModifierBase"/>-variations are treatable in the same manner, i.e. any distinct functionality is moved away from the <see cref="MagicSword"/> 
    /// class to the implementations.
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