using DependencyInversion;
using DependencyInversion_AbstractFactoryPattern.AlarmFactories;
using System.Collections.Generic;

namespace DependencyInversion_AbstractFactoryPattern
{
    /// <summary>
    /// 
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The abstract factory is responsible for creating objects of a common domain. Below, as an example, we use it 
        /// to create visible and audible alarm for a collection of sensors.
        /// </summary>
        /// <remarks>
        /// Abstract factories de-couple the creation-logic. Very useful for supporting multiple platforms, for example, or
        /// situation where we need to defer the creation based on run-time conditions we won't know about until, well, run-time.
        /// 
        /// Also good for database-connectivity, API clients and such, i.e. for initiating resources that appear complex or with 
        /// big initialization cost.
        /// 
        /// Furthermore, they are good for abstracting away logic that may undergo modification later in the development process.
        /// For example, with an abstract factory we can allow one type of consumer more resources than another, by offering one a 
        /// different factory-creator than the other.
        /// </remarks>
        public static void Main()
        {
            // A collection of spells must have alarms attached to them:
            TemperatureSpell temperatureSpell1 = new TemperatureSpell("Temp1");
            TemperatureSpell temperatureSpell2 = new TemperatureSpell("Temp2");
            List<ISpell> spellsCollection = new() { temperatureSpell1, temperatureSpell2 };

            // For standard alarms, we use a standard alarm factory:
            ISpellAlarmFactory standardAlarmFactory = new StandardSpellsAlarmFactory();
            spellsCollection.ForEach(sensor =>
            {
                sensor.AttachSpellAlarm(standardAlarmFactory.CreateVisibleAlarm());
                sensor.AttachSpellAlarm(standardAlarmFactory.CreateAudibleAlarm());
            });

            SpellBook spellBook = new(spellsCollection);
            spellBook.TestAlarms();

            // But for other scenarios, we might create 'enhanced' alarms via a different factory implementation:
            spellBook = new(spellsCollection);
            ISpellAlarmFactory enhancedAlarmFactory = new EnhancedSpellsAlarmFactory();
            spellsCollection.ForEach(sensor =>
            {
                sensor.AttachSpellAlarm(enhancedAlarmFactory.CreateVisibleAlarm());
                sensor.AttachSpellAlarm(enhancedAlarmFactory.CreateAudibleAlarm());
            });
            spellBook = new(spellsCollection);
            spellBook.TestAlarms();
        }
    }
}