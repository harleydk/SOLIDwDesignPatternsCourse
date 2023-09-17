using System.Collections.Generic;
using System.Diagnostics;
using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class SpellBook
    {
        private readonly List<ISpell> _spells;

        public SpellBook(List<ISpell> spells)
        {
            _spells = spells;
        }

        public SpellBookOperationResult TestAlarms()
        {
            _spells.ForEach(alarm => alarm.RaiseSpellAlarms());
            return SpellBookOperationResult.PresumedSucceeded;
        }
    }
}