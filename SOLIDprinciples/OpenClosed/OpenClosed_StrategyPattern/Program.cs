using OpenClosed_StrategyPattern.HitPointModifiers;
using OpenClosed_StrategyPattern.IntimidationStrategies;
using System.Diagnostics;

namespace OpenClosed_StrategyPattern
{
    /// <summary>
    /// The plot thickens!: We now need to provide different calculations for the <see cref="IntimidationHitPointModifier"/>.
    ///
    /// We could do several new different variations of the class, i.e. "Taunt<see cref="IntimidationHitPointModifier"/>" or 
    /// "Rage<see cref="IntimidationHitPointModifier"/>" and similar, but it will only be the intimidation-force that changes, so 
    /// this seems like overkill. By using the strategy design pattern we don't have to make new near copies of classes, but can 
    /// maintain just one - that we thus keep open for extension.
    /// </summary>
    public sealed class Program
    {
        public static void Main()
        {
            HitPointModifierBase[] hitPointModifiers =
            {
                new ProficiencyHitPointModifier(modifierValue: 4, abilityBonus: 1, ProficiencyLevel.Guardian),
                new IntimidationHitPointModifier( modifierValue: 10, abilityBonus: 1, new TauntIntimidationForceStrategy(TauntLevel.MasterTaunt) ),
                new IntimidationHitPointModifier( modifierValue: 10, abilityBonus: 1, new SpellAffectedIntimidationForceStrategy(Spell.CloudMind ^ Spell.EarthConsume ) )
            };
            MagicSword magicSword = new(hitPointModifiers);

            int hitPoints = 16;
            double totalModifierValue = magicSword.GetTotalModifierValue(hitPoints);
            Debug.WriteLine($"{nameof(totalModifierValue)} across all {nameof(hitPointModifiers)} is {totalModifierValue}");
        }
    }

}