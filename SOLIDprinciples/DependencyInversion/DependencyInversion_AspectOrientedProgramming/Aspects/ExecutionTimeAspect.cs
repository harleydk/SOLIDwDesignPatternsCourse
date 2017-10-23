using PostSharp.Aspects;
using System;
using System.Diagnostics;

namespace DependencyInversion_AspectOrientedProgramming
{
    [Serializable]
    public class ExecutionTimeAspect : OnMethodBoundaryAspect

    {
        [NonSerialized]
        private Stopwatch stopWatch;

        public override void OnEntry(MethodExecutionArgs args)

        {
            stopWatch = Stopwatch.StartNew();

            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)

        {
            string method = new StackTrace().GetFrame(1).GetMethod().Name;
            string message = string.Format("The method: [{0}] took {1}  ms to execute.", method, stopWatch.ElapsedMilliseconds);

            Debug.WriteLine(message);

            base.OnExit(args);
        }
    }
}