namespace DependencyInversion
{
    public static class Program
    {
        /// <summary>
        /// The dependency inversion principle states that a class should not declare its own dependencies - rather it should be provided with them. 
        /// 
        /// Below, a poor example: A <see cref="SpellBook"/> declares a number of dependencies within its own confines, wherefore it becomes 
        /// hard-coupled to these dependencies.
        /// </summary>
        public static void Main()
        {
            // Initialization. Within these methods, there's a lot of creation logic going on.
            SpellBook spellBook = new();
            spellBook.InitializeSpells();
            spellBook.InitializeSpellAlarms();
            spellBook.AttachAlarmsToSpells();

            // At some point, we wish to write status values to a log.
            spellBook.AttachSpellLogger();
            spellBook.WriteAllTemperatureSpellsStatusToLogger();
        }
    }
}