using System.Collections.Generic;
using DependencyInversion;

namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class SpellBook
    {
        private readonly List<ISpell> _spells = new();

        public SpellBook WithSpell(ISpell spell)
        {
            _spells.Add(spell);
            return this;
        }
    }
}