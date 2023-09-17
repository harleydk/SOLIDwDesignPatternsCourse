using DependencyInversion;

namespace DependencyInversion_fluidInterfacePattern
{
    /// <summary>
    /// Demonstrates 'fluid interface pattern' aka “Method chaining” ;
    /// a common technique where each method returns an object and all these methods can be chained together to form a single statement.
    /// This can also be considered a form of injection of dependencies. 
    /// Can make for more readable code.
    /// </summary>
    public static partial class Program
    {
        public static void Main()
        {
            _ = new SpellBook(/* No list of spells  here - we'll granularly add them via the fluid interface pattern instead */)
                .WithSpell(new TemperatureSpell(spellId: "Temp1"))
                .WithSpell(new PressureSpell())
                .WithSpell(new TemperatureSpell(spellId: "Temp2"))
                .WithSpell(new TemperatureSpell(spellId: "Temp3"))
                .WithSpell(new TemperatureSpell(spellId: "Temp4"))
                .WithSpell(new PressureSpell());
        }
    }
}