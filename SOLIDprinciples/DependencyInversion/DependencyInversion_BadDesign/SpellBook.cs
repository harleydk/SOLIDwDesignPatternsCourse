using System.Collections.Generic;

namespace DependencyInversion
{
    /// <summary>
    /// A <see cref="SpellBook"/>, that holds a number of spells.
    /// </summary>
    /// <remarks>
    /// This class does not honor the dependency inversion principle - lots of hard-wired dependencies.
    /// </remarks>
    public sealed class SpellBook
    {
        private TemperatureSpell _temperatureSpell1;
        private TemperatureSpell _temperatureSpell2;
        private PressureSpell _pressureSpell;
        private DisplayAlarm _displayAlarm;
        private WarningBellAlarm _warningBellAlarm;
        private TemperatureSpellLogger _temperatureSpellLogger;

        public SpellBookOperationResult InitializeSpells()
        {
            _temperatureSpell1 = new TemperatureSpell(spellId: "Temp1");
            _temperatureSpell2 = new TemperatureSpell(spellId: "Temp2");
            _pressureSpell = new PressureSpell();
            return SpellBookOperationResult.PresumedSucceeded;
        }

        public SpellBookOperationResult InitializeSpellAlarms()
        {
            _displayAlarm = new DisplayAlarm();
            _warningBellAlarm = new WarningBellAlarm();
            return SpellBookOperationResult.PresumedSucceeded;
        }

        public SpellBookOperationResult AttachAlarmsToSpells()
        {
            _temperatureSpell1.AttachSpellAlarm(_displayAlarm);

            _temperatureSpell2.AttachSpellAlarm(_displayAlarm);
            _temperatureSpell2.AttachSpellAlarm(_warningBellAlarm);

            _pressureSpell.AttachSpellAlarm(_displayAlarm);
            _pressureSpell.AttachSpellAlarm(_warningBellAlarm);

            return SpellBookOperationResult.PresumedSucceeded;
        }

        public SpellBookOperationResult AttachSpellLogger()
        {
            _temperatureSpellLogger = new TemperatureSpellLogger(new DiagnosticsLogger());
            return SpellBookOperationResult.PresumedSucceeded;
        }

        /// <summary>
        /// Write data for all temperature-spells to the diagnostics-logger.
        /// </summary>
        public SpellBookOperationResult WriteAllTemperatureSpellsStatusToLogger()
        {
            TemperatureSpellData spellData1 = new(SpellId: _temperatureSpell1.Id, _temperatureSpell1.GetTemperature());
            TemperatureSpellData spellData2 = new(SpellId: _temperatureSpell2.Id, _temperatureSpell2.GetTemperature());
            _temperatureSpellLogger.WriteAllTemperatureSpellsDataToLog(new List<TemperatureSpellData> { spellData1, spellData2 });
            return SpellBookOperationResult.PresumedSucceeded;
        }
    }
}