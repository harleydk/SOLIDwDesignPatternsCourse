﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterfaceSegregation_BadDesign
{
    public class TraditionalSensorCabinet : ISensorCabinet
    {
        private CabinetAlarm _cabinetAlarm;
        private string _cabinetLastOpenedByUserName;
        private string _cabinetAdministratorUserName;

        public event EventHandler<SensorEventArgs> SensorEvent;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public IList<ISensor> Sensors { get; private set; }

        public TraditionalSensorCabinet(string cabinetAdministratorUserName)
        {
            Debug.Assert(!string.IsNullOrEmpty(cabinetAdministratorUserName), "cabinet-admin user name should never be null");

            _cabinetAlarm = new CabinetAlarm();
            _cabinetAdministratorUserName = cabinetAdministratorUserName;
        }

        public void FireCabinetOpenedEvent(object sender, CabinetOpenedEventArgs e)
        {
            _cabinetLastOpenedByUserName = e.CabinetOpenedByUserName;
            CabinetOpenedEvent?.Invoke(this, e);
        }

        public void AddSensor(ISensor sensor)
        {
            if (Sensors == null)
                Sensors = new List<ISensor>();

            Sensors.Add(sensor);
        }

        public void FireSensorEvent(object sender, SensorEventArgs e)
        {
            SensorEvent?.Invoke(this, e);
        }

        public void RaiseCabinetOpenAlarm()
        {
            Debug.Assert(_cabinetAlarm != null, "Cabinet alarm not initialized");
            _cabinetAlarm.RaiseCabinetAlarm();
        }

        public void ResetCabinetOpenAlarm()
        {
            Debug.Assert(_cabinetAlarm != null, "Cabinet alarm not initialized");
            _cabinetAlarm.ResetCabinetAlarm();
        }

        public string GetCabinetLastOpenedByUserId()
        {
            return _cabinetLastOpenedByUserName;
        }
    }
}