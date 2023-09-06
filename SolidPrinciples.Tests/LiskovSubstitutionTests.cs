using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiskovSubstitution_BadDesign;

namespace SolidPrinciples.Tests
{
    [TestClass]
    public class LiskovSubstitutionTests
    {
        #region bad design tests

        [TestMethod]
        public void BadDesign_StandardVoltageAlarmCanRaiseAlarm()
        {
            // arrange
            double standardAlarmThresholdValue = -1d;
            StandardVoltageAlarm standardVoltageAlarm = new(standardAlarmThresholdValue);

            // act
            standardVoltageAlarm.RaiseAlarm();

            // assert
            Assert.AreEqual(standardVoltageAlarm.NumberOfAlarmsRaised, 1);
        }

        [TestMethod]
        public void BadDesign_StandardVoltageAlarmCanDetectVoltageDrop()
        {
            // arrange
            double standardAlarmThresholdValue = 1d;
            StandardVoltageAlarm standardVoltageAlarm = new(standardAlarmThresholdValue);

            // act
            bool hasVoltageDroppedBelowThreshold = standardVoltageAlarm.HasVoltageDroppedBelowThreshold(0);

            // assert
            Assert.IsTrue(hasVoltageDroppedBelowThreshold);
        }

        [TestMethod]
        public void BadDesign_NewVoltageAlarmCanRaiseAlarm_repeatsXtimes()
        {
            // arrange
            double newVoltageAlarmThreshold = -1d; // make it so that no matter what, an alarm will be raised.
            NewVoltageAlarm newVoltageAlarm = new(newVoltageAlarmThreshold);

            // act
            newVoltageAlarm.RaiseAlarm(); // repeats alarm 3 times

            // assert
            Assert.AreEqual(newVoltageAlarm.NumberOfAlarmsRaised, 3);
        }

        [TestMethod]
        public void BadDesign_NewVoltageAlarmCanResetAlarm()
        {
            // arrange
            double newVoltageAlarmThreshold = -1d; // make it so that no matter what, an alarm will be raised.
            NewVoltageAlarm newVoltageAlarm = new(newVoltageAlarmThreshold);

            // act
            newVoltageAlarm.RaiseAlarm();
            newVoltageAlarm.ResetNumberOfAlarmsRaised();

            // assert
            Assert.AreEqual(newVoltageAlarm.NumberOfAlarmsRaised, 0);
        }

        [TestMethod]
        public void BadDesign_VolageSensorCanReadSensorValue()
        {
            // arrange
            LiskovSubstitution_BadDesign.VoltageSensor voltageSensor = new();

            // act
            voltageSensor.ReadCurrentSensorVoltage();

            // assert
            Assert.IsTrue(voltageSensor.CurrentSensorVoltage > 3);
        }

        #endregion

        #region good design tests

        [TestMethod]
        public void GoodDesign_NewVoltageAlarmShouldResetAlarms()
        {
            // arrange
            LiskovSubstitution_GoodDesign.VoltageAlarmBase newVoltageAlarm = new LiskovSubstitution_GoodDesign.NewVoltageAlarm(5d);

            // act
            var shouldResetNumberOfAlarmsRaised = newVoltageAlarm.ShouldResetNumberOfAlarmsRaised();

            // assert
            Assert.IsTrue(shouldResetNumberOfAlarmsRaised);
        }

        [TestMethod]
        public void GoodDesign_NewVoltageAlarmCanGetAlarmRepetitionsCount()
        {
            // arrange
            LiskovSubstitution_GoodDesign.VoltageAlarmBase newVoltageAlarm = new LiskovSubstitution_GoodDesign.NewVoltageAlarm(5d);

            // act
            int numberOfAlarmRepetitions = newVoltageAlarm.GetNumberOfAlarmRepetitions();

            // assert
            Assert.AreEqual(numberOfAlarmRepetitions, 3);
        }

        [TestMethod]
        public void GoodDesign_NewVoltageAlarmCanGetMaxVoltageLevelForAlarm()
        {
            // arrange
            LiskovSubstitution_GoodDesign.VoltageAlarmBase newVoltageAlarm = new LiskovSubstitution_GoodDesign.NewVoltageAlarm(5d);

            // act
            double maxAllowedVoltage = newVoltageAlarm.GetMaximumAllowableVoltageLevel();

            // assert
            Assert.AreEqual(maxAllowedVoltage, 5d);
        }

        #endregion
    }
}
