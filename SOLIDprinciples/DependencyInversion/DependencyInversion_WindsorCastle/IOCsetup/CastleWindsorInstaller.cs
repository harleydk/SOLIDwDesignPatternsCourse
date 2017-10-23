using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DependencyInversion_GoodDesign;
using System;

namespace DependencyInversion_WindsorCastle.IOCsetup
{
    public class CastleWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log4net.Config.XmlConfigurator.Configure();
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithAppConfig());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            //register alarms
            container.Register(Component.For<IAlarm>().ImplementedBy<DisplayAlarm>().LifestyleTransient());
            container.Register(Component.For<IAlarm>().ImplementedBy<WarningBellAlarm>().LifestyleTransient());

            //register sensors
            container.Register(Component.For<ISensor>().ImplementedBy<PressureSensor>().LifestyleTransient().
                DependsOn(Dependency.OnComponent<IAlarm, DisplayAlarm>()));

            container.Register(Component.For<ISensor>().ImplementedBy<TemperatureSensor>()
                .LifestyleTransient()
                .DependsOn(Dependency.OnComponent<IAlarm, WarningBellAlarm>())
                .DependsOn(Dependency.OnValue("sensorId", Guid.NewGuid().ToString()))
            );

            // register loggers
            container.Register(Component.For<TemperatureSensorLogger>().ImplementedBy<TemperatureSensorLogger>().LifestyleTransient()); // gets the ILogger automatically

            // register SensorCabinet
            container.Register(Component.For<SensorCabinet>().ImplementedBy<SensorCabinet>().LifestyleSingleton()); // gets all ISensors automatically
        }
    }
}