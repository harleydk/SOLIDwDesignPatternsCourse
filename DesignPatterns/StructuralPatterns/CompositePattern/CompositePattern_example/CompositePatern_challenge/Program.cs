using System;

namespace CompositePatern_challenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            throw new NeverGotAroundToImplementingThisException(
                "Consider using the SKAT example of IRpaProcessUnitComponent - to represent unknown" +
                "hierarchy levels on rpa-identification/-extraction jobs. Just need some method to call... easy to fake on (write to db, or some such");


            //TODO: do _remember_ to promote the execute-as-group abstraction - or it would make more sense to just add a reference-to-self variable....?


        }

        private class NeverGotAroundToImplementingThisException : Exception
        {
            public NeverGotAroundToImplementingThisException(string message) : base(message)
            {
            }
        }
    }
}