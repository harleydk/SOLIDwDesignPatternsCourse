using System;

namespace DependencyInversion
{
    public sealed class TemperatureSpell : Spell
    {
        public string Id { get; private set; }

        public TemperatureSpell(string spellId)
        {
            Id = spellId;
        }

        /// <summary>
        /// Get the current temperature of the spell.
        /// </summary>
        public double GetTemperature()
        {
            Random rnd = new();
            return rnd.NextDouble();
        }
    }

}