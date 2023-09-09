using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterfaceSegregation_BadDesign
{
    public sealed class SensorCabinetWithoutAlarm : ISensorCabinet // implements the full set of ISensorCabinet functionality!
    {
        private readonly string _cabinetAdministratorUserName;

        public event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        public event EventHandler<SensorEventArgs> SensorEvent;

        public IList<ISensor> Sensors { get; private set; }

        public SensorCabinetWithoutAlarm(string cabinetAdministratorUserName)
        {
            Debug.Assert(!string.IsNullOrEmpty(cabinetAdministratorUserName), "cabinet-admin user name should never be null");
            _cabinetAdministratorUserName = cabinetAdministratorUserName;
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

        public string GetCabinetLastOpenedByUserId()
        {
            return _cabinetAdministratorUserName; //! Lisskov substitution violation
        }

        public void RaiseCabinetOpenAlarm()
        {
            throw new NotImplementedException(); // Interface segregation violation
        }

        public void ResetCabinetOpenAlarm()
        {
            throw new NotImplementedException(); // Interface segregation violation
        }

        public void FireCabinetOpenedEvent(object sender, CabinetOpenedEventArgs e)
        {
            throw new NotImplementedException(); // Interface segregation violation
        }
    }
}