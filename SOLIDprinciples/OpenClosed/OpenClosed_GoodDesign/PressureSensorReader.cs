using OpenClosed_GoodDesign.PressureSensorImplementations;
using System.Linq;

namespace OpenClosed_GoodDesign
{
    public sealed class PressureSensorReader
    {
        private readonly TankPressureSensorBase[] _tankPressureSensors;

        public PressureSensorReader(TankPressureSensorBase[] tankPressureSensors)
        {
            _tankPressureSensors = tankPressureSensors;
        }

        /// <summary>
        /// Gets the average pressure across all sensors.
        /// </summary>
        /// <remarks>
        /// Given the introduction of the abstraction, we needn't modify the method if we introduce a new type of sensor.
        /// </remarks>
        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            double totalPressureFromAllSensors = 0;
            _tankPressureSensors.ToList().ForEach(sensor =>
            {
                totalPressureFromAllSensors += sensor.CalculatePressure(waterIntakeVelocity);
            });
            
            int numberOfPressureSensors = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensors;
            return averagePressureAcrossSensors;
        }
    }
}