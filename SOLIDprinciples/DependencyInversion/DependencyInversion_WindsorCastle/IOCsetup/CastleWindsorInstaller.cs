using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Diagnostics;

namespace DependencyInversion_WindsorCastle.IOCsetup
{
    public class CastleWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Configure the log4net logging component. We could do this in the assemblyinfo-class as well.
            log4net.Config.XmlConfigurator.Configure();

            // Register the log4net logging component with the IOC container, and use the app-config settings for that.
            container.AddFacility<LoggingFacility>(f =>
               f.LogUsing(LoggerImplementation.Log4net).
               WithAppConfig()); // note: deprecated

            // Allow the IOC container to register multiple implementations of an interface.
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            // Register all alarms - get them dynamically from the calling assembly (this), so we won't 
            // have to wire them up by manually.
            container.Register(Classes.FromThisAssembly()
                 .BasedOn(typeof(IAlarm))
                  .WithServiceBase()
                 .Configure(c => c.LifestyleTransient()));

            var registeredAlarms = container.ResolveAll<IAlarm>();
            Debug.Assert(registeredAlarms.Length == 2, "We should have registered two IAlarm-implementations");

            // Register sensors. Note how the 'depends on' ensures that the pressure-sensor is instantiated with 
            // a Display-alarm, when we call resolve a pressure-sensor - we won't have to hand it over ourselves.
            container.Register(Component.For<ISensor>().ImplementedBy<PressureSensor>().LifestyleTransient().
                DependsOn(Dependency.OnComponent<IAlarm, DisplayAlarm>()));

            // Note how the 'depends on' configures a constructor-parameter to the TemperatureSensor, so we won't
            // have to provide this ourselves.
            container.Register(Component.For<ISensor>().ImplementedBy<TemperatureSensor>()
                .LifestyleTransient()
                .DependsOn(Dependency.OnComponent<IAlarm, WarningBellAlarm>())
                .DependsOn(Dependency.OnValue("sensorId", Guid.NewGuid().ToString()))
            );

            // register custom loggers
            container.Register(Component.For<TemperatureSensorLogger>().ImplementedBy<TemperatureSensorLogger>().LifestyleTransient()); // gets the ILogger automatically

            // register SensorCabinet.
            // * NOTE HOW we register the class, which isn't based on an interface. But we can register it to itself.
            // And, in doing so, we can avoid having the interface abstraction until it's truly needed.
            // ** NOTE ALSO HOW we don't specify the class' dependencies, even though they are required. These are all
            // wired up by the IOC-container, and we don't have to inject anything into the class.
            container.Register(Component.For<SensorCabinet>().ImplementedBy<SensorCabinet>().LifestyleSingleton()); 
        }
    }
}