using OpenClosed_BadDesign.PressureSensorImplementations;

namespace OpenClosed_BadDesign
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
        /// This method breaks with the open/closed principle, in that we calculate the result in consideration 
        /// to a specific sensor-type. So if we introduce a new type of sensor, we must now modify this method accordingly.
        /// </remarks>
        public double GetAveragePressureAcrossSensors(int waterIntakeVelocity)
        {
            double totalPressureFromAllSensors = 0;

            foreach (TankPressureSensorBase tankPressureSensor in _tankPressureSensors)
            {
                if (tankPressureSensor is InternalTankPressureSensor)
                {
                    double calculatePressure(int waterIntakeVelocity)
                    {
                        double internalTankOutletSize = tankPressureSensor.CalculateTankOutletSize();
                        double totallyBogusPressureValue = (InternalTankPressureSensor.TANK_INTERNAL_THICKNESS * waterIntakeVelocity) * internalTankOutletSize;
                        return totallyBogusPressureValue;
                    }
                    totalPressureFromAllSensors += calculatePressure(waterIntakeVelocity);
                }
                else if (tankPressureSensor is ExternalTankPressureSensor)
                {
                    double calculatePressure(int waterIntakeVelocity)
                    {
                        double tankOutletSize = tankPressureSensor.CalculateTankOutletSize();
                        double tankIsolationFactor = ((ExternalTankPressureSensor)tankPressureSensor).GetTankIsolationFactor();
                        double totallyBogusPressureValue = tankIsolationFactor * tankOutletSize;
                        return totallyBogusPressureValue;
                    }
                    totalPressureFromAllSensors += calculatePressure(waterIntakeVelocity);
                }
            }

            int numberOfPressureSensors = _tankPressureSensors.Length;
            double averagePressureAcrossSensors = totalPressureFromAllSensors / numberOfPressureSensors;
            return averagePressureAcrossSensors;
        }
    }
}