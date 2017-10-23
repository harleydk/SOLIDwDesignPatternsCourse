using Castle.Windsor;
using DependencyInversion_WindsorCastle.IOCsetup;

namespace DependencyInversion_GoodDesign
{
    public static partial class Program
    {
        private static IWindsorContainer _iocContainer;

        public static void Main()
        {
            // setup IOC container
            _iocContainer = new Castle.Windsor.WindsorContainer();
            _iocContainer.Install(new CastleWindsorInstaller());

            SensorCabinet sensorCabinet = _iocContainer.Resolve<SensorCabinet>();
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            // By removing the logger from the sensor-cabinet, we forego problems with the single-responsibility principle.
            TemperatureSensorLogger temperatureSensorLogger = _iocContainer.Resolve<TemperatureSensorLogger>();
            var temperatureSensorData = sensorCabinet.GetAllTemperatureSensorsData();
            temperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(temperatureSensorData);
        }
    }
}