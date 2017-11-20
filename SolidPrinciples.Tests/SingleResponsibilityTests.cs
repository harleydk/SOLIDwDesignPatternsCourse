using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class SingleResponsibilityTests
    {
        #region bad design tests
        [TestMethod]
        public void BadDesignTestCanReadSensorvalue()
        {
            // arrange
            SingleResponsibility_BadDesign.SensorReader sensorReader = new SingleResponsibility_BadDesign.SensorReader();

            // act
            string sensorValue = sensorReader.ReadSensorValue();

            // assert
            int sensorValueStringLength = sensorValue.Length;
            Assert.AreEqual(sensorValueStringLength, 40);


        }

        #endregion
    }
}
