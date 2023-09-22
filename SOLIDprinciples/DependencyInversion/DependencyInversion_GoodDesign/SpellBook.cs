using DependencyInversion;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_GoodDesign
{
    public sealed class SpellBook(IEnumerable<ISpell> spells)
    {
        public IEnumerable<TemperatureSpellData> GetAllTemperatureSpellsData()
        {
            IEnumerable<TemperatureSpell> temperatureSpells = spells.Where(sensor => sensor is TemperatureSpell).Cast<TemperatureSpell>();
            foreach (TemperatureSpell temperatureSpell in temperatureSpells)
            {
                TemperatureSpellData temperatureSensorData = GetTemperatureSpellData(temperatureSpell);
                yield return temperatureSensorData;
            };
        }

        private TemperatureSpellData GetTemperatureSpellData(TemperatureSpell temperatureSpell)
        {
            string spellId = temperatureSpell.Id;
            double temperature = temperatureSpell.GetTemperature();

            Debug.Assert(!string.IsNullOrWhiteSpace(spellId), $"{nameof(spellId)} should not be null or blank");
            Debug.Assert(temperature >= 0, $"{nameof(temperature)} should be >= 0");

            return new TemperatureSpellData(spellId, temperature);
        }
    }
}