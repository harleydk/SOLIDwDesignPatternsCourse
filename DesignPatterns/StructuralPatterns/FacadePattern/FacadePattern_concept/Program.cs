using System;

namespace FacadePattern
{
    internal class Program
    {
        /// <summary>
        /// The Facade pattern is for when we need to present a unified front, combining calls to x sub-systems into a common front.
        /// </summary>
        /// <example>
        /// Real-life use includes...
        ///  - whenever we use API's we tend to call their individual methods, instead of facading away a specific need -
        ///  - fx.a security API that authenticates, authorizes, sets a timer for allowed access, so on and so forth.
        ///
        ///  - remember the facade pattern is about reducing complexity.
        ///  - fx.
        ///
        ///  - for a role-playing game, we can use the facade pattern to reduce a multitude of calculations that take place when summing up a player's experience points based on her
        ///
        ///  - We can also use the facade pattern to present a simplified, 'most-often-used' scenario front of a highly complex API. Fx. an image-processing API, which has 2-3 facades for dealing with different scenarios.
        ///
        ///
        /// </example>
        public static void Main()
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}