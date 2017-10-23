using OpenClosed_GoodDesign.PressureSensorImplementations;

namespace OpenClosed_GoodDesign
{
    public sealed class PressureSensorReader
    {
        private TankPressureSensorBase[] _tankPressureSensors;

        public PressureSensorReader()
        {
            _tankPressureSensors = new TankPressureSensorBase[]
            {
                new InternalTankPressureSensor(tankCapacity: 4),
                new InternalTankPressureSensor(tankDiameter: 15),
                new ExternalTankPressureSensor(1,100)
             };
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

            foreach (var tankPressureSensor in _tankPressureSensors)
                totalPressureFromAllSensors += tankPressureSensor.CalculatePressure(waterIntakeVelocity);

            int numberOfPressureSensores = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensores;
            return averagePressureAcrossSensors;
        }
    }
}