namespace LiskovSubstitution_BadDesign
{
    public sealed class Program
    {
        // The Liskov Substitution Principle states that an object with a certain interface can be replaced by a different object that implements that same interface while retaining all the correctness of the original program. That means that not only does the interface have to have exactly the same types, but the behavior has to remain correct as well.

        // A VoltageSensor-class reads a sensor-voltage and raises an alarm if the voltage dips below a given threshold. This works well for a Standard-voltage alarm, but a newly introduced NewVoltageAlarm() implementation introduces different requirements and thus breaks the Liskov substitution principle.
        public static void Main()
        {
            VoltageSensor voltageSensor = new();
            voltageSensor.SetVoltageAlarm(new StandardVoltageAlarm(3.3d));
            voltageSensor.ReadCurrentSensorVoltage();
            voltageSensor.RaiseAlarmIfVoltageBelowMinimum();
        }
    }
}