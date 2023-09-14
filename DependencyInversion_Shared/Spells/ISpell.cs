namespace DependencyInversion
{
    public interface ISpell
    {
        void AttachSpellAlarm(ISpellAlarm spellAlarm);

        void RaiseSpellAlarms();
    }

}