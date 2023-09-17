using OpenClosed_GoodDesign.HitPointModifiers;
using System.Diagnostics;

namespace OpenClosed_GoodDesign
{
    public sealed class Program
    {
        public static void Main()
        {
            int hitPoints = 10;

            HitPointModifierDecorator modifier1 = new IntimidationHitPointModifier(modifierValue: 6, abilityBonus: 1, NullObjectHitPointModifier.Create()); 
            //Debug.Assert(modifier1.CalculateModifierValue(hitPoints) == 10); // 6+1 +3 intimidation-points + 0 for the null-object modifier
            HitPointModifierDecorator modifier2 = new ProficiencyHitPointModifier(modifierValue: 4, abilityBonus: 1, ProficiencyLevel.Guardian, modifier1); 
            //Debug.Assert(modifier2.CalculateModifierValue(hitPoints) == 20); // 4+1+(int)Guardian + 10 for modifier1
            HitPointModifierDecorator modifier3 = new IntimidationHitPointModifier(modifierValue: 3, abilityBonus: 2, modifier2);
            //Debug.Assert(modifier3.CalculateModifierValue(hitPoints) == 28); // 3+2 +3 intimidation-points + 20 for modifier2

            MagicSword magicSword = new(modifier3);

            int totalModifierValue = magicSword.GetTotalModifierValue(hitPoints);
            Debug.WriteLine($"{nameof(totalModifierValue)} across all modifiers is {totalModifierValue}");
        }
    }
}