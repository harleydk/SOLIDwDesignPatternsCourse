using System.Collections.Generic;
using DependencyInversion;

namespace DependencyInversion_fluidInterfacePattern
{
    /// <summary>
    /// Demonstrates 'fluid interface pattern' aka “Method chaining” ;
    /// a common technique where each method returns an object and all these methods can be chained together to form a single statement.
    /// This can also be considered a form of injection of dependencies. 
    /// Can make for more readable code.
    /// </summary>
    public static partial class Program
    {
        public static void Main()
        {
            SensorCabinet sensorCabinet = new SensorCabinet(/* No list of sensors here - we'll granularly add them via the fluid interface pattern instead */)
                .WithSensor(new TemperatureSensor(sensorId: "Temp1"))
                .WithSensor(new PressureSensor())
                .WithSensor(new TemperatureSensor(sensorId: "Temp2"))
                .WithSensor(new TemperatureSensor(sensorId: "Temp3"))
                .WithSensor(new TemperatureSensor(sensorId: "Temp4"))
                .WithSensor(new PressureSensor());

            sensorCabinet.WriteAllTemperatureSensorsDataToLog(new DiagnosticsLogger());
        }
    }
}