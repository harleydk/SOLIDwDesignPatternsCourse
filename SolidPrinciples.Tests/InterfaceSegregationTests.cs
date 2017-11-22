using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class InterfaceSegregationTests
    {
        private class TestSensor : InterfaceSegregation_BadDesign.ISensor
        {
            public string SensorId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string SensorValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        }

        [TestMethod]
        public void TestCanAddSensor()
        {
            // arrange
            InterfaceSegregation_BadDesign.TraditionalSensorCabinet sensorCabinet = new InterfaceSegregation_BadDesign.TraditionalSensorCabinet("TestAdminUserName");

            // act
            sensorCabinet.AddSensor(new TestSensor());

            // assert
            Assert.AreEqual(sensorCabinet.Sensors.Count, 1);
        }

        [TestMethod]
        public void TestTraditionalCabinetLastOpenedByUserId()
        {
            // arrange
            string cabinetUserId = "FoobarUser";
            InterfaceSegregation_BadDesign.TraditionalSensorCabinet sensorCabinet = new InterfaceSegregation_BadDesign.TraditionalSensorCabinet(cabinetUserId);

            // act
            string cabinetLastOpenedByUserId = sensorCabinet.GetCabinetLastOpenedByUserId();

            // assert
            Assert.IsNull(cabinetLastOpenedByUserId);
        }


        [TestMethod]
        [ExpectedException(typeof(System.NotImplementedException))]
        public void TesttNewCabinetCanNotResetAlarms()
        {
            // arrange
            string cabinetUserId = "FoobarUser";
            InterfaceSegregation_BadDesign.SensorCabinetWithoutAlarm sensorCabinet = new InterfaceSegregation_BadDesign.SensorCabinetWithoutAlarm(cabinetUserId);

            // act/assert
            sensorCabinet.ResetCabinetOpenAlarm();
            
        }

        //ResetCabinetOpenAlarm

    }

}
