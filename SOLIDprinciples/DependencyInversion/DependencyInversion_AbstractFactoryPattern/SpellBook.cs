using System.Collections.Generic;
using System.Diagnostics;
using DependencyInversion;

namespace DependencyInversion_AbstractFactoryPattern
{
    public sealed class SpellBook(List<ISpell> spells)
    {
        public SpellBookOperationResult TestAlarms()
        {
            spells.ForEach(alarm => alarm.RaiseSpellAlarms());
            return SpellBookOperationResult.PresumedSucceeded;
        }
    }
}