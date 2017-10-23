using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterfaceSegregation_BetterDesign
{
    public sealed class SensorCabinetWithoutAlarm : ICabinetSensoring
    {
        public event EventHandler<SensorEventArgs> SensorEvent;

        public IList<ISensor> Sensors { get; private set; }

        public SensorCabinetWithoutAlarm(string cabinetAdministratorUserName)
        {
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
    }
}