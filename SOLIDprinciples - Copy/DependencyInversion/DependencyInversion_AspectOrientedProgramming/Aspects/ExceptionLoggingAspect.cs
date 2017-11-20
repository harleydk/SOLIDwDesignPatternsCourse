using PostSharp.Aspects;
using System;
using System.Diagnostics;

namespace DependencyInversion_AspectOrientedProgramming
{
    [Serializable]
    [System.AttributeUsage(System.AttributeTargets.All)]
    public sealed class ExceptionLoggingAspect : OnMethodBoundaryAspect
    {
        public ExceptionLoggingAspect()
        {
            base.AspectPriority = 5;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            object type = args.Instance;

            Debug.WriteLine("Handling exception by way of AOP. " + args.Exception);

            // do soemthing to handle the error here.
        }
    }
}