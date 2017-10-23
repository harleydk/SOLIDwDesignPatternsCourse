using System;
using System.Collections.Generic;

namespace InterfaceSegregation_BetterDesign
{
    public interface ICabinetSensoring
    {
        IList<ISensor> Sensors { get; }

        void AddSensor(ISensor sensor);

        event EventHandler<SensorEventArgs> SensorEvent;

        void FireSensorEvent(object sender, SensorEventArgs e);
    }
}