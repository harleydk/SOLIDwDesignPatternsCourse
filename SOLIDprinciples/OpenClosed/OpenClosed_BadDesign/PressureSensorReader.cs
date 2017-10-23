using OpenClosed_BadDesign.PressureSensorImplementations;
using System.Diagnostics;

namespace OpenClosed_BadDesign
{
    public sealed class PressureSensorReader
    {
        private object[] _tankPressureSensors;

        /// <summary>
        /// In the class' constructor, a number of tank-pressure sensors are new'ed up.
        /// </summary>
        public PressureSensorReader()
        {
            _tankPressureSensors = new object[]
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
        /// This method breaks with the open/closed principle, in that we need to cast to a specific sensor-type or we won't know which exact method to call, in order to obtain the pressure from the sensor in question. So if we introduce a new type of sensor, we must modify this method accordingly.
        /// </remarks>
        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            Debug.Assert(waterIntakeVelocity > 0, "waterIntakeVelocity should be greater than 0");
            Debug.Assert(_tankPressureSensors != null, "Array of tank-pressure sensors should not be null");
            Debug.Assert(_tankPressureSensors.Length > 0, "Array of tank-pressure sensors should hold elements");

            double totalPressureFromAllSensors = 0;

            foreach (var tankPressureSensor in _tankPressureSensors)
            {
                // We need to cast to a specific type, or we won't know which method to call.
                if (tankPressureSensor is InternalTankPressureSensor)
                    totalPressureFromAllSensors += (tankPressureSensor as InternalTankPressureSensor).CalculatePressure(waterIntakeVelocity);
                else if (tankPressureSensor is ExternalTankPressureSensor)
                    totalPressureFromAllSensors += (tankPressureSensor as ExternalTankPressureSensor).GetTankPressure(waterIntakeVelocity);
            }

            int numberOfPressureSensores = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensores;
            Debug.Assert(averagePressureAcrossSensors > 0, "Average tank-pressure should be > 0");
            return averagePressureAcrossSensors;
        }
    }
}