using System;

namespace TemplatePattern
{
    public static class Program
    {
        /// <summary>
        /// The Template Pattern allows us to define a skeleton method - 'template methods' - for execution of a series of steps, with the possibility of relegating one or more steps to variant classes.
        /// </summary>
        /// <example>
        /// Real life uses include...
        ///     - Setup-projects of various kinds, where an environment - any one - needs to be set-up through a number of steps, though accomodate minor local considerations such as physical location (ISS, anyone), selected battle-arena for a game, chosen user profile, so on and so forth.
        ///     - Security operations, where access rights and such are set up by a fixed mechanism, though possible to grant/revoke certain rights for certain individuals.
        ///     - Data exports, where data is gathered through a number of pre-defined steps but the last step, the actual persistence of data, may vary.
        ///     - Generally, all places where 'first this, then that, then this', i.e. we execute a number of predefined steps. Surprisingly many.
        /// </example>
        public static void Main()
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();

            // Wait for user
            Console.ReadKey();
        }
    }
}