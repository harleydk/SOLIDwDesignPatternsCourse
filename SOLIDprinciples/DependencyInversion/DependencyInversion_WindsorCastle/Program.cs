using Castle.Windsor;
using DependencyInversion_WindsorCastle.IOCsetup;

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
            
        }
    }
}