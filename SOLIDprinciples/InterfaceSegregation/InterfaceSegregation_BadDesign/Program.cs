using System.Diagnostics;

namespace InterfaceSegregation_BadDesign
{
    public sealed class Program
    {
        private const string CABINET_ADMIN_USER_NAME = "F. Oobar";
        private static ISensorCabinet traditionalSensorCabinet = new TraditionalSensorCabinet(CABINET_ADMIN_USER_NAME);
        private static ISensorCabinet sensorCabinetWithoutAlarm = new SensorCabinetWithoutAlarm(CABINET_ADMIN_USER_NAME);

        /// <summary>
        /// The interface segregation principle states that no class should be forced to implement interface-methods it has not need for. Below, a SensorCabinetWithoutAlarm() shouldn't have to implement ISensorCabinet-methods regarding alarms.
        /// </summary>
        public static void Main()
        {
            traditionalSensorCabinet.CabinetOpenedEvent += SensorCabinet_CabinetOpenedEvent;
            traditionalSensorCabinet.SensorEvent += TraditionalSensorCabinet_SensorEvent;
            string traditionalSensorCabinetOpenedBy = traditionalSensorCabinet.GetCabinetLastOpenedByUserId();

            sensorCabinetWithoutAlarm.SensorEvent += SensorCabinetWithoutAlarm_SensorEvent1;
            string cabinetLastOpenedBy = sensorCabinetWithoutAlarm.GetCabinetLastOpenedByUserId(); // fails - and should not be possible. But who would ever call it, when they know it's a sensorcabinet sans alarms...

            traditionalSensorCabinet.CabinetOpenedEvent -= SensorCabinet_CabinetOpenedEvent;
            traditionalSensorCabinet.SensorEvent -= TraditionalSensorCabinet_SensorEvent;
            sensorCabinetWithoutAlarm.SensorEvent -= SensorCabinetWithoutAlarm_SensorEvent1;
        }

        private static void SensorCabinetWithoutAlarm_SensorEvent1(object sender, SensorEventArgs sensorEventArgs)
        {
            Debug.WriteLine($"Logging sensor {sensorEventArgs.SensorId}'s value of {sensorEventArgs.SensorValue}");
        }

        private static void TraditionalSensorCabinet_SensorEvent(object sender, SensorEventArgs sensorEventArgs)
        {
            Debug.WriteLine($"Logging sensor {sensorEventArgs.SensorId}'s value of {sensorEventArgs.SensorValue}");
        }

        private static void SensorCabinet_CabinetOpenedEvent(object sender, CabinetOpenedEventArgs cabinetOpenedEventArgs)
        {
            string _cabinetLastOpenedByUserName = cabinetOpenedEventArgs.CabinetOpenedByUserName;
            traditionalSensorCabinet.RaiseCabinetOpenAlarm();
            traditionalSensorCabinet.ResetCabinetOpenAlarm();
        }

        #region triggering the sensor-event, for testing

        // Triggering the sensor-event - subclass and call directly.

        // For triggering the sensor-event:
        //foobarSensorCabinet df = new foobarSensorCabinet("fdsaf");
        //df.ProgrammaticalEventHandler();

        //private static void Df_SensorEvent(object sender, SensorEventArgs e)
        //{
        //    Debug.WriteLine("Logging sensor event..");
        //}

        //private class foobarSensorCabinet : TraditionalSensorCabinet
        //{
        //    public foobarSensorCabinet(string name) : base(name)
        //    { }

        //    public void ProgrammaticalEventHandler()
        //    {
        //        SensorEventArgs f = new SensorEventArgs();
        //        f.SensorId = "1";
        //        f.SensorValue = "falue";
        //        base.OnSensorEvent(null, f);
        //    }
        //}

        #endregion triggering the sensor-event, for testing
    }
}