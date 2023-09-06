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
        ///  - remember the facade pattern is about reducing complexity. For example: 
        ///
        ///  * for a role-playing game, we can use the facade pattern to reduce a multitude of calculations that take place when 
        ///  summing up a player's experience points based on X number of diverse criteria.
        ///
        ///  * We can also use the facade pattern to present a simplified, 'most-often-used' scenario front of a highly complex API. 
        ///  Fx. an image-processing API, which has 2-3 facades for dealing with different scenarios.
        ///
        ///  * When you design and build large or complex microservice-based applications with multiple client apps, 
        ///  a good approach to consider can be an API Gateway. This could also be considered an example of the facade pattern.
        /// </example>
        public static void Main()
        {
            Facade facade = new();

            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}