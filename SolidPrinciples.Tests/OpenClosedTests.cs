using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class OpenClosedTests
    {
        #region bad design tests

        [TestMethod]
        public void BadDesign_TestCanGetAveragePressureAcrossSensors()
        {
            // arrange
            OpenClosed_BadDesign.PressureSensorReader pressureSensorReader = new OpenClosed_BadDesign.PressureSensorReader();
            int waterIntakeVelocity = 1;
            
            // act
            double averagePressureSensor = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);

            // assert
            Assert.IsTrue(averagePressureSensor>  3d);
        }

        [TestMethod]
        public void BadDesign_TestCanGetInternalSensorPressure()
        {
            // arrange
            OpenClosed_BadDesign.PressureSensorImplementations.InternalTankPressureSensor internalTankPressureSensor = new OpenClosed_BadDesign.PressureSensorImplementations.InternalTankPressureSensor();
            int waterIntakeVelocity = 1;

            // act
            double pressure = internalTankPressureSensor.CalculatePressure(waterIntakeVelocity);

            // assert
            Assert.AreEqual(pressure, 4.5d);
        }

        [TestMethod]
        public void BadDesign_TestCanGetExternalSensorPressure()
        {
            // arrange
            OpenClosed_BadDesign.PressureSensorImplementations.ExternalTankPressureSensor externalTankPressureSensor = new OpenClosed_BadDesign.PressureSensorImplementations.ExternalTankPressureSensor();
            int waterIntakeVelocity = 1;

            // act
            double pressure = externalTankPressureSensor.GetTankPressure(waterIntakeVelocity);

            // assert
            Assert.AreEqual(pressure, 4.2d);
        }

        #endregion

        #region good design tests

        [TestMethod]
        public void GoodDesign_TestCanGetAveragePressureAcrossSensors()
        {
            // arrange
            OpenClosed_GoodDesign.PressureSensorReader pressureSensorReader = new OpenClosed_GoodDesign.PressureSensorReader();
            int waterIntakeVelocity = 1;

            // act
            double averagePressureSensor = pressureSensorReader.GetAveragePressureAcrossSensors(waterIntakeVelocity);

            // assert
            Assert.IsTrue(averagePressureSensor > 3d);
        }

        [TestMethod]
        public void GoodDesign_TestCanGetInternalSensorPressure()
        {
            // arrange
            OpenClosed_GoodDesign.PressureSensorImplementations.TankPressureSensorBase internalTankPressureSensor = new OpenClosed_GoodDesign.PressureSensorImplementations.InternalTankPressureSensor();
            int waterIntakeVelocity = 1;

            // act
            double pressure = internalTankPressureSensor.CalculatePressure(waterIntakeVelocity);

            // assert
            Assert.AreEqual(pressure, 4.5d);
        }

        [TestMethod]
        public void GoodDesign_TestCanGetExternalSensorPressure()
        {
            // arrange
            OpenClosed_GoodDesign.PressureSensorImplementations.TankPressureSensorBase externalTankPressureSensor = new OpenClosed_GoodDesign.PressureSensorImplementations.ExternalTankPressureSensor();
            int waterIntakeVelocity = 1;

            // act
            double pressure = externalTankPressureSensor.CalculatePressure(waterIntakeVelocity);

            // assert
            Assert.AreEqual(pressure, 4.2d);
        }

        #endregion

    }
}
