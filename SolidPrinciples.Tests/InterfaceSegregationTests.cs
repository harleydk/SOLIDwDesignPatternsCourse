using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class InterfaceSegregationTests
    {
        #region bad design tests

        private class TestSensor : InterfaceSegregation_BadDesign.ISensor
        {
            public string SensorId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string SensorValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        }

        [TestMethod]
        public void BadDesign_TestCanAddSensor()
        {
            // arrange
            InterfaceSegregation_BadDesign.TraditionalSensorCabinet sensorCabinet = new InterfaceSegregation_BadDesign.TraditionalSensorCabinet("TestAdminUserName");

            // act
            sensorCabinet.AddSensor(new TestSensor());

            // assert
            Assert.AreEqual(sensorCabinet.Sensors.Count, 1);
        }

        [TestMethod]
        public void BadDesign_TestTraditionalCabinetLastOpenedByUserId()
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
        public void BadDesign_TesttNewCabinetCanNotResetAlarms()
        {
            // arrange
            string cabinetUserId = "FoobarUser";
            InterfaceSegregation_BadDesign.SensorCabinetWithoutAlarm sensorCabinet = new InterfaceSegregation_BadDesign.SensorCabinetWithoutAlarm(cabinetUserId);

            // act/assert
            sensorCabinet.ResetCabinetOpenAlarm();
        }

        #endregion

        #region better design tests

        [TestMethod]
        public void BetterDesign_ImplementsRightInterface()
        {
            // arrange
            InterfaceSegregation_BetterDesign.SensorCabinetWithoutAlarm sensorCabinetWithoutAlarm = new InterfaceSegregation_BetterDesign.SensorCabinetWithoutAlarm("foobarAdmin");

            // act
            Type[] interfacesImplementedByClass = sensorCabinetWithoutAlarm.GetType().GetInterfaces();

            // assert
            Assert.AreEqual(interfacesImplementedByClass.Length, 1);
            Assert.IsTrue(interfacesImplementedByClass.Any(interfaceImpl => interfaceImpl.Name == "ICabinetSensoring"));
            Assert.IsFalse(interfacesImplementedByClass.Any(interfaceImpl => interfaceImpl.Name == "ICabinetOpenAlarm"));
        }

        #endregion

        #region good design tests

        [TestMethod]
        public void GoodDesign_ImplementsRightInterface()
        {
            // arrange
            InterfaceSegregation_GoodDesign.SensorCabinetWithoutAlarm sensorCabinetWithoutAlarm = new InterfaceSegregation_GoodDesign.SensorCabinetWithoutAlarm("foobarAdmin");

            // act
            Type[] interfacesImplementedByClass = sensorCabinetWithoutAlarm.GetType().GetInterfaces();

            // assert
            Assert.AreEqual(interfacesImplementedByClass.Length, 2);
            Assert.IsTrue(interfacesImplementedByClass.Any(interfaceImpl => interfaceImpl.Name == "ICabinetSensorEventing"));
            Assert.IsFalse(interfacesImplementedByClass.Any(interfaceImpl => interfaceImpl.Name == "ICabinetOpenAlarm"));
            Assert.IsTrue(interfacesImplementedByClass.Any(interfaceImpl => interfaceImpl.Name == "ICabinetSensorAttaching"));
        }

        #endregion

    }

}
