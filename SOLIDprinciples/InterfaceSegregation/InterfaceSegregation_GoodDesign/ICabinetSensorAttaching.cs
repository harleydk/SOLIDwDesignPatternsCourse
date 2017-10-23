using System.Collections.Generic;

namespace InterfaceSegregation_GoodDesign
{
    public interface ICabinetSensorAttaching
    {
        IList<ISensor> Sensors { get; }

        void AddSensor(ISensor sensor);
    }
}