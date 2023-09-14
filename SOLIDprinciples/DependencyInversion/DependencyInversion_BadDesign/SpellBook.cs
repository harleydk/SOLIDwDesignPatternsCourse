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
        private TemperatureSpell _temperatureSpell1 { get; set; }
        private TemperatureSpell _temperatureSpell2 { get;  set; }
        private PressureSpell _pressureSpell { get;  set; }
        private DisplayAlarm _displayAlarm { get;  set; }
        private WarningBellAlarm _warningBellAlarm { get;  set; }

        private TemperatureSpellLogger _temperatureSpellLogger { get;  set; }

        public void InitializeSpells()
        {
            _temperatureSpell1 = new TemperatureSpell(spellId: "Temp1");
            _temperatureSpell2 = new TemperatureSpell(spellId: "Temp2");
            _pressureSpell = new PressureSpell();
        }

        public void InitializeSpellAlarms()
        {
            _displayAlarm = new DisplayAlarm();
            _warningBellAlarm = new WarningBellAlarm();
        }

        public void AttachAlarmsToSpells()
        {
            _temperatureSpell1.AttachSpellAlarm(_displayAlarm);

            _temperatureSpell2.AttachSpellAlarm(_displayAlarm);
            _temperatureSpell2.AttachSpellAlarm(_warningBellAlarm);

            _pressureSpell.AttachSpellAlarm(_displayAlarm);
            _pressureSpell.AttachSpellAlarm(_warningBellAlarm);
        }

        public void AttachSpellLogger()
        {
            _temperatureSpellLogger = new TemperatureSpellLogger(new DiagnosticsLogger());
        }

        /// <summary>
        /// Write data for all temperature-spells to the diagnostics-logger.
        /// </summary>
        public void WriteAllTemperatureSpellsStatusToLogger()
        {
            TemperatureSpellData spellData1 = new(SpellId: _temperatureSpell1.Id, _temperatureSpell1.GetTemperature());
            TemperatureSpellData spellData2 = new(SpellId: _temperatureSpell2.Id, _temperatureSpell2.GetTemperature());
            _temperatureSpellLogger.WriteAllTemperatureSpellsDataToLog(new List<TemperatureSpellData> { spellData1, spellData2 });
        }
    }
}