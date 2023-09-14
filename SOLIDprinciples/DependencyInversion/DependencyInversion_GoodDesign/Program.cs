using DependencyInversion_GoodDesign.Configuration;
using DependencyInversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_GoodDesign
{
    public static partial class Program
    {
        /// <summary>
        /// The good design stipulates that ...
        /// ... primarily, we do our creation logic in the composition root, preferably from configuration - if possible.
        /// ... secondary, we also remove the logging-consideration from the SensorCabinet-class altogether. Besides breaking the 
        /// dependency inversion principle, we can easily identify this as a tendency to break with the single responsibility principles.
        /// </summary>
        /// <remarks>
        /// Here, the 'main' method is our so-called 'composition root', i.e. the entry-point into the application and 
        /// thus the suitable place for all the dependencies to be created. 
        /// </remarks>
        public static void Main(string[] args)
        {
            // Let's get the sensors from configuration. We could new them up, of course, if they don't lend themselves easily to configuration.
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile(@"spellsAndAlarms.json").Build();
            List<SpellConfiguration> spellConfig = new();
            config.Bind("Spells", spellConfig);
            Debug.Assert(spellConfig.Any(), "No spells initialized from config");

            // Initialize the sensors based on their configuration data, and add them to the sensor-cabinet.
            IEnumerable<ISpell> spellsCollection = InitializeSpells(spellConfig);
            SpellBook spellBook = new(spellsCollection);

            // At some point, we wish to write temperature sensor values to a log.
            // By removing the logger from the sensor-cabinet, we forego problems with the single-responsibility principle.
            IEnumerable<TemperatureSpellData> temperatureSpellsData = spellBook.GetAllTemperatureSpellsData();

            TemperatureSpellLogger temperatureSensorLogger = InitializeTemperatureSpellsLogger();
            temperatureSensorLogger.WriteAllTemperatureSpellsDataToLog(temperatureSpellsData);
        }

        private static IEnumerable<ISpell> InitializeSpells(List<SpellConfiguration> spellConfigurations)
        {
            foreach (SpellConfiguration spellConfig in spellConfigurations)
            {
                // Initialize sensor
                ISpell sensor = spellConfig.SpellType switch
                {
                    SpellType.TemperatureSpell => new TemperatureSpell(spellConfig.SpellId),
                    SpellType.PressureSpell => new PressureSpell(),
                    _ => throw new ArgumentException($"Invalid {nameof(SpellType)} {spellConfig.SpellType}")
                };

                // attach alarms
                foreach (AlarmConfiguration alarmConfig in spellConfig.Alarms)
                {
                    ISpellAlarm alarm = InitializeAlarm(alarmConfig);
                    sensor.AttachSpellAlarm(alarm);
                }

                yield return sensor;
            }
        }

        private static ISpellAlarm InitializeAlarm(AlarmConfiguration alarmConfig)
        {
            ISpellAlarm alarm = alarmConfig.AlarmType switch
            {
                AlarmType.DisplayAlarm => new DisplayAlarm(),
                AlarmType.WarningBellAlarm => new WarningBellAlarm(),
                _ => throw new ArgumentException($"No {nameof(AlarmType)} '{alarmConfig.AlarmType}'")
            };
            return alarm;
        }

        private static TemperatureSpellLogger InitializeTemperatureSpellsLogger()
        {
            DiagnosticsLogger diagnosticsLogger = new();
            TemperatureSpellLogger temperatureSensorLogger = new(diagnosticsLogger);
            return temperatureSensorLogger;
        }
    }
}