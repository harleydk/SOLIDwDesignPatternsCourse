using System.Collections.Generic;

namespace DependencyInversion
{
    /// <summary>
    /// A logger that writes temperature spell data.
    /// </summary>
    public sealed class TemperatureSpellLogger
    {
        private readonly DiagnosticsLogger _diagnosticsLogger;

        public TemperatureSpellLogger(DiagnosticsLogger diagnosticsLogger)
        {
            _diagnosticsLogger = diagnosticsLogger;
        }

        /// <summary>
        /// Write data for all temperature-sensors to the log.
        /// </summary>
        public void WriteAllTemperatureSpellsDataToLog(IEnumerable<TemperatureSpellData> temperatureSpellsData)
        {
            foreach(TemperatureSpellData spellData in temperatureSpellsData)
            {
                string logMessage = $"Spell {spellData.SpellId} reported value {spellData.SpellTemperature:N2}";
                _diagnosticsLogger.WriteToLog(logMessage);
            }
        }
    }
}