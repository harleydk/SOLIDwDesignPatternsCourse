namespace LiskovSubstitution_GoodDesign
{
    public sealed class Program
    {
        // A 'good example' on Liskov substitution is simply to not allow our sub-classes to differ in the meaning of their
        // implementations. I.e. no explicit paths for certain sub-types, no strenghtening of conditions etc. 
        // If a need to break away from limitations of the originals class arises, 
        // we can add the required functionality to that original class.

        // By introducing an abstract base-class, which takes into consideration the diverse implementations, 
        // we can ensure sub-class compatibility. Given additional requirements - for example, we only need to modify the base-class,
        // single point of maintainability.
        public static void Main()
        {
            VoltageSensor voltageSensor = new VoltageSensor();
            voltageSensor.ReadCurrentSensorVoltage();
            voltageSensor.RaiseAlarmIfVoltageBelowThreshold();
        }
    }
}