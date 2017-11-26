using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class DependencyInversionTests
    {
        #region bad design tests

        [TestMethod]
        public void BadDesign_TestCanInitializeDependencies()
        {
            // arrange
            DependencyInversion_BadDesign.SensorCabinet sensorCabinet = new DependencyInversion_BadDesign.SensorCabinet();

            // act/assert
            Assert.IsTrue(sensorCabinet.TemperatureSensor1 != null);
            Assert.IsInstanceOfType(sensorCabinet.TemperatureSensor1, typeof(DependencyInversion_BadDesign.TemperatureSensor));
        }

        #endregion

        #region better design tests

        [TestMethod]
        public void BetterDesign_TestCanInitializeWithSensors()
        {
            // arrange
            DependencyInversion_BetterDesign.ISensor sensor = new DependencyInversion_BetterDesign.PressureSensor();
            IEnumerable<DependencyInversion_BetterDesign.ISensor> sensors = new List<DependencyInversion_BetterDesign.ISensor>() { sensor };
            DependencyInversion_BetterDesign.SensorCabinet sensorCabinet = new DependencyInversion_BetterDesign.SensorCabinet(sensors);

            // act
            int temperatureSensorCount = sensorCabinet.Sensors.Count(sensorImplementation => sensorImplementation.GetType() == typeof(DependencyInversion_BetterDesign.TemperatureSensor));

            // assert
            Assert.AreEqual(temperatureSensorCount, 2);
        }

        #endregion

        #region good design tests

        [TestMethod]
        public void GoodDesign_TestHasNoLongerDependencyOnLogger()
        {
            // arrange
            DependencyInversion_GoodDesign.SensorCabinet sensorCabinet = new DependencyInversion_GoodDesign.SensorCabinet(null);

            // act
            bool hasNoLongerALoggingMethod = sensorCabinet.GetType().GetMethods().Any(method => method.Name == "WriteAllTemperatureSensorsDataToLog");

            // assert
            Assert.IsTrue(hasNoLongerALoggingMethod);
        }

        #endregion


    }
}
