namespace DependencyInversion
{
    public interface ISpell
    {
        SpellAlarmAttachStatus AttachSpellAlarm(ISpellAlarm spellAlarm);

        SpellAlarmRaiseStatus RaiseSpellAlarms();
    }

}