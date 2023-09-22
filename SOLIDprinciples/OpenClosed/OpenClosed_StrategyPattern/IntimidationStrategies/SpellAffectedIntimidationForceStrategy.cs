using System;

namespace OpenClosed_StrategyPattern.IntimidationStrategies
{
    public sealed class SpellAffectedIntimidationForceStrategy(Spell spell) : IIntimidationForceStrategy
    {
        public int GetIntimidationForce()
        {
            int spellIntimidationForces = (int)spell;
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