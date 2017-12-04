using Castle.Windsor;
using DependencyInversion_WindsorCastle.IOCsetup;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DependencyInversion_WindsorCastle
{
    public static partial class Program
    {
        private static IWindsorContainer _iocContainer;

        public static void Main()
        {
            // setup IOC container
            _iocContainer = new Castle.Windsor.WindsorContainer();
            _iocContainer.Install(new CastleWindsorInstaller());

            // Resolve the sensor-cabinet...
            SensorCabinet sensorCabinet = _iocContainer.Resolve<SensorCabinet>();
            // ... note how this resolves the class, all of its dependencies (and, in turn, their dependencies, too).
            // Go ahead - put a breakpoing on the 'resolve' line and investigate the object, and note how it's all 
            // wired up for us.

            IEnumerable<IAlarm> sensorData = sensorCabinet.GetAllSensorAlarms();
            Debug.Assert(sensorData.Count() == 2, "The IOC-container should have mounted two sensors into our sensor-cabinet at this point");

        }
    }
}