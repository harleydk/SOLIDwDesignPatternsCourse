using System;

namespace OpenClosed_StrategyPattern.IntimidationStrategies
{
    public sealed class SpellAffectedIntimidationForceStrategy : IIntimidationForceStrategy
    {
        private readonly Spell _spell;

        public SpellAffectedIntimidationForceStrategy(Spell spell)
        {
            _spell = spell;
        }

        public int GetIntimidationForce()
        {
            int spellIntimidationForces = (int)_spell;
            return spellIntimidationForces;
        }
    }

    [Flags]
    public enum Spell
    {
        FireBreath = 1,
        FrostWalk = 2,
        EarthConsume = 4,
        CloudMind = 8
    }
}