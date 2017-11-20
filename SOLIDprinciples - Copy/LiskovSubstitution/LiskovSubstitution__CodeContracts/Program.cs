using LiskovSubstitution_CodeContracts;

namespace LiskovSubstitution__CodeContracts
{
    /// <summary>

    /// </summary>
    /// <see cref="https://msdn.microsoft.com/en-us/library/dd264808(v=vs.110).aspx"/>
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Use Debug.Assert when you want ensure that certain things are as you expect when developing the code (and in later maintenance development).
             *
             * Use code contracts when you want to assure that conditions are true in both debug and release. Contracts also allow certain forms of static analysis that can be helpful in verifying that your program is "correct".
             */

            VoltageSensor voltageSensor = new VoltageSensor();
            voltageSensor.ReadCurrentSensorVoltage();
            voltageSensor.RaiseAlarmIfVoltageBelowThreshold();
        }
    }
}