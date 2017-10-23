using System.Diagnostics;

namespace InterfaceSegregation_BetterDesign
{
    public sealed class Program
    {
        private const string CABINET_ADMIN_USER_NAME = "F. Oobar";
        private static TraditionalSensorCabinet traditionalSensorCabinet = new TraditionalSensorCabinet(CABINET_ADMIN_USER_NAME);
        private static ICabinetSensoring sensorCabinetWithoutAlarm = new SensorCabinetWithoutAlarm(CABINET_ADMIN_USER_NAME);

        /// <summary>
        /// The better design is to split the general ISensorCabinet interface out into seperate interfaces, and thus allow the SensorCabinetWithoutAlarm to only implement those interfaces it should implement.
        /// </summary>
        public static void Main()
        {
            traditionalSensorCabinet.CabinetOpenedEvent += SensorCabinet_CabinetOpenedEvent;
            traditionalSensorCabinet.SensorEvent += TraditionalSensorCabinet_SensorEvent;
            string traditionalSensorCabinetOpenedBy = traditionalSensorCabinet.GetCabinetLastOpenedByUserId();

            sensorCabinetWithoutAlarm.SensorEvent += SensorCabinetWithoutAlarm_SensorEvent1;
            //! No longer possible:
            //# string cabinetLastOpenedBy = sensorCabinetWithoutAlarm.GetCabinetLastOpenedByUserId(); .

            // This works, but still there's a code-smell coming off that ICabinetSensoring interface...
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
    }
}