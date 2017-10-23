using DependencyInversion_GoodDesign;
using Ninject;
using System;

namespace DependencyInversion.IOCsetup
{
    public static class NinjectInstaller
    {
        public static IKernel CreateKernel()
        {
            Ninject.IKernel DIcontainer = new Ninject.StandardKernel();

            // With the Ninject log4net extension, it's not necessary to configure the ILogger - happens automatically.
            //#log4net.Config.XmlConfigurator.Configure();
            //#container.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithAppConfig());

            return DIcontainer;
        }

        public static void BindDependencyInjections(Ninject.IKernel container)
        {
            // With Ninject, as opposed to Castle Windsor, it's not necessary to resolve ICollections-resolving.
            //# container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            //register alarms
            container.Bind<IAlarm>().To<DisplayAlarm>().InTransientScope();
            container.Bind<IAlarm>().To<WarningBellAlarm>().InTransientScope();

            //register sensors
            container.Bind<ISensor>().To<PressureSensor>().InTransientScope()
                .WithConstructorArgument(container.Get<DisplayAlarm>());

            container.Bind<ISensor>().To<TemperatureSensor>().InTransientScope()
                   .WithConstructorArgument(container.Get<WarningBellAlarm>())
                   .WithConstructorArgument("sensorId", Guid.NewGuid().ToString());

            // register
            container.Bind<TemperatureSensorLogger>().ToSelf()
                .InSingletonScope(); // gets the ILogger automatically

            // register SensorCabinet
            container.Bind<SensorCabinet>().ToSelf()
                .InSingletonScope(); // gets all ISensors automatically
        }
    }
}