using System;
using System.Collections.Generic;

namespace InterfaceSegregation_BadDesign
{
    //? Note: where do fat interfaces usually derive from? Historic efforts. The World-view of once was is no longer valid. */

    public interface ISensorCabinet
    {
        IList<ISensor> Sensors { get; }

        void AddSensor(ISensor sensor);

        event EventHandler<SensorEventArgs> SensorEvent;

        void FireSensorEvent(object sender, SensorEventArgs e);

        void RaiseCabinetOpenAlarm();

        event EventHandler<CabinetOpenedEventArgs> CabinetOpenedEvent;

        void FireCabinetOpenedEvent(object sender, CabinetOpenedEventArgs e);

        void ResetCabinetOpenAlarm();

        string GetCabinetLastOpenedByUserId();
    }
}