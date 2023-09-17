using System.Collections.Generic;

namespace DependencyInversion
{
    public class Spell : ISpell
    {
        protected List<ISpellAlarm> _spellAlarms = new();

        public SpellAlarmAttachStatus AttachSpellAlarm(ISpellAlarm spellAlarm)
        {
            _spellAlarms.Add(spellAlarm);
            return SpellAlarmAttachStatus.PresumedAttached;
        }

        public SpellAlarmRaiseStatus RaiseSpellAlarms()
        {
            _spellAlarms.ForEach(alarm => alarm.RaiseSpellAlarm());
            return SpellAlarmRaiseStatus.PresumedRaised;
        }
    }

    public enum SpellAlarmAttachStatus
    {
        Attached,
        NotAttached,
        PresumedAttached
    }

    public enum SpellAlarmRaiseStatus
    {
        Raised,
        NotRaised,
        PresumedRaised
    }

}