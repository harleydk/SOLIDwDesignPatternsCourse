using PostSharp.Aspects;
using System;
using System.Diagnostics;

namespace DependencyInversion_AspectOrientedProgramming
{
    [Serializable]
    public sealed class LogMethodCallAspect : OnMethodBoundaryAspect
    {
        public LogMethodCallAspect()
        {
            base.AspectPriority = 10;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            object type = args.Instance;
            Debug.WriteLine($"{args.Instance.ToString()} called {args.Method.Name}");
        }
    }
}