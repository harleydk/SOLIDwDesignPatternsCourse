using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class SingleResponsibilityTests
    {
        #region bad design - tests
        [TestMethod]
        public void BadDesign_TestCanReadSensorvalue()
        {
            // arrange
            SingleResponsibility_BadDesign.SensorReader sensorReader = new SingleResponsibility_BadDesign.SensorReader();

            // act
            string sensorValue = sensorReader.ReadSensorValue();

            // assert
            int sensorValueStringLength = sensorValue.Length;
            Assert.AreEqual(sensorValueStringLength, 36);
        }

        [TestMethod]
        public void BadDesign_TestCanWriteToLogFile()
        {
            // arrange
            SingleResponsibility_BadDesign.SensorReader sensorReader = new SingleResponsibility_BadDesign.SensorReader();
            string tempPathDir = Path.GetTempPath();

            // act
            int tempFilesPathCountBeforeWrite = Directory.EnumerateFiles(tempPathDir).Count();
            sensorReader.WriteSensorValueToLog("foobar");

            // assert
            int tempFilesPathCountAfterWrite = Directory.EnumerateFiles(tempPathDir).Count();
            Assert.AreEqual(tempFilesPathCountAfterWrite, tempFilesPathCountBeforeWrite + 1);
        }

        #endregion

        #region good design - tests

        [TestMethod]
        public void GoodDesign_TestCanReadSensorvalue()
        {
            // arrange
            SingleResponsibility_GoodDesign.SensorReader sensorReader = new SingleResponsibility_GoodDesign.SensorReader();

            // act
            string sensorValue = sensorReader.ReadSensorValue();

            // assert
            int sensorValueStringLength = sensorValue.Length;
            Assert.AreEqual(sensorValueStringLength, 36);
        }

        [TestMethod]
        public void GoodDesign_TestCanWriteToLogFile()
        {
            // arrange
            SingleResponsibility_GoodDesign.FileLogger fileLogger = new SingleResponsibility_GoodDesign.FileLogger();
            string tempPathDir = Path.GetTempPath();

            // act
            int tempFilesPathCountBeforeWrite = Directory.EnumerateFiles(tempPathDir).Count();
            fileLogger.WriteToLog("foobar");

            // assert
            int tempFilesPathCountAfterWrite = Directory.EnumerateFiles(tempPathDir).Count();
            Assert.AreEqual(tempFilesPathCountAfterWrite, tempFilesPathCountBeforeWrite + 1);
        }

        #endregion

    }
}
