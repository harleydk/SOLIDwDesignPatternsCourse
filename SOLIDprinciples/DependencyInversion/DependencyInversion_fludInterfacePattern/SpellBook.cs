using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DependencyInversion;

namespace DependencyInversion_fluidInterfacePattern
{
    public sealed class SpellBook
    {
        private List<ISpell> _spells = new ();

        public SpellBook WithSpell(ISpell spell)
        {
            _spells.Add(spell);
            return this;
        }
    }
}