using OpenClosed_DecoratorPattern.PressureSensorImplementations;
using System.Linq;

namespace OpenClosed_DecoratorPattern
{
    public sealed class PressureSensorReader
    {
        private readonly TankPressureSensorBase[] _tankPressureSensors;

        public PressureSensorReader(TankPressureSensorBase[] tankPressureSensors)
        {
            _tankPressureSensors = tankPressureSensors;
            
        }

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