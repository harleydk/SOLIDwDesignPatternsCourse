using DependencyInversion.IOCsetup;
using Ninject;

namespace DependencyInversion_GoodDesign
{
    public static partial class Program
    {
        private static Ninject.IKernel _iocContainer;

        public static void Main()
        {
            // setup IOC container
            _iocContainer = NinjectInstaller.CreateKernel();
            NinjectInstaller.BindDependencyInjections(_iocContainer);

            SensorCabinet sensorCabinet = _iocContainer.Get<SensorCabinet>();
            // now do some monitoring...

            // At some point, we wish to write temperature sensor values to a log.
            // By removing the logger from the sensor-cabinet, we forego problems with the single-responsibility principle.
            TemperatureSensorLogger temperatureSensorLogger = _iocContainer.Get<TemperatureSensorLogger>();
            var temperatureSensorData = sensorCabinet.GetAllTemperatureSensorsData();
            temperatureSensorLogger.WriteAllTemperatureSensorsDataToLog(temperatureSensorData);
        }
    }
}