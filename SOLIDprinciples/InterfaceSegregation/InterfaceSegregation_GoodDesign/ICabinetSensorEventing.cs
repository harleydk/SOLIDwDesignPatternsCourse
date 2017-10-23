using System;
using System.Collections.Generic;

namespace InterfaceSegregation_GoodDesign
{
    public interface ICabinetSensorEventing
    {
        event EventHandler<SensorEventArgs> SensorEvent;

        void FireSensorEvent(object sender, SensorEventArgs e);
    }
}