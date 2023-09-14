using System.Collections.Generic;

namespace DependencyInversion
{
    public class Spell : ISpell
    {
        protected List<ISpellAlarm> _spellAlarms = new();

        public void AttachSpellAlarm(ISpellAlarm spellAlarm)
        {
            _spellAlarms.Add(spellAlarm);
        }

        public void RaiseSpellAlarms()
        {
            _spellAlarms.ForEach(alarm => alarm.RaiseSpellAlarm());
        }
    }
}