using System;
using System.Threading;

namespace DependencyInversion_AspectOrientedProgramming
{
    public static class Program
    {
        /// <summary>
        /// Aspect Oriented Programming (AOP) is a programming paradigm that enables you to define policies to seamlessly manage the cross-cutting concerns in applications.
        /// I.e. AOP can be leveraged to remove intermingled code, such as logging, and exception handling, from our dependencies.
        /// </summary>
        /// <remarks>
        /// 'Pst, aspects are a feature with Castle Windsor IOC, too'.
        /// </remarks>
        public static void Main()
        {
            AspectsTesterClass aspectsTester = new AspectsTesterClass();
            aspectsTester.LongRunningMethod();
            aspectsTester.ExceptionThrowingMethod();
        }
    }

    [ExceptionLoggingAspect]
    [LogMethodCallAspect]
    public class AspectsTesterClass
    {
        [ExecutionTimeAspect]
        public void LongRunningMethod()
        {
            Thread.Sleep(3000);

        }

        public void ExceptionThrowingMethod()
        {
            throw new NotImplementedException();
        }
    }
}