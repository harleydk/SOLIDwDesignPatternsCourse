using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DependencyInversion_GoodDesign;

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
            DependencyInversion_BadDesign.SensorCabinet sensorCabinet = new();

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
            DependencyInversion_BetterDesign.SensorCabinet sensorCabinet = new(sensors);

            // act
            int temperatureSensorCount = sensorCabinet.Sensors.Count(sensorImplementation => sensorImplementation.GetType() == typeof(DependencyInversion_BetterDesign.PressureSensor));

            // assert
            Assert.AreEqual(temperatureSensorCount, 1);
        }

        #endregion

        #region good design tests

        private class MockSensor : DependencyInversion_GoodDesign.ISensor
        {
            public void AttachAlarm(IAlarm sensorAlarm)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public void GoodDesign_TestHasNoLongerDependencyOnLogger()
        {
            // arrange
            MockSensor mockedSensor = new();
            DependencyInversion_GoodDesign.SensorCabinet sensorCabinet = new(new List<ISensor> { mockedSensor });

            // act
            bool hasLongerALoggingMethod = sensorCabinet.GetType().GetMethods().Any(method => method.Name == "WriteAllTemperatureSensorsDataToLog");

            // assert
            Assert.IsFalse(hasLongerALoggingMethod);
        }

        #endregion


    }
}
