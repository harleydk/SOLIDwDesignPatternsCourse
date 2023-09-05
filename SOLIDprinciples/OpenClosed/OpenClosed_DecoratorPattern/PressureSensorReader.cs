using OpenClosed_DecoratorPattern.PressureSensorImplementations;

namespace OpenClosed_DecoratorPattern
{
    public sealed class PressureSensorReader
    {
        private AbstractTankPressureSensor[] _tankPressureSensors;

        public PressureSensorReader()
        {
            /*#
            //_tankPressureSensors = new AbstractTankPressureSensor[]
            //{
            //    new InternalTankPressureSensor(tankCapacity: 4),
            //    new InternalTankPressureSensor(tankDiameter: 15),
            //    new ExternalTankPressureSensor(1,100)
            // };
            */

            AbstractTankPressureSensor internalTankPressureSensor = new InternalTankPressureSensor(tankCapacity: 4);
            AbstractTankPressureSensor shockAbsorbableInternalTankPressureSensor = new ShockAbsorbableTankPressureSensor(internalTankPressureSensor, 10);
            AbstractTankPressureSensor shockAbsorbableInternalTankPressureSensorWithTemperature = new TemperatureTankPressureSensor(shockAbsorbableInternalTankPressureSensor, 10, 12);
            _tankPressureSensors = new AbstractTankPressureSensor[] { shockAbsorbableInternalTankPressureSensorWithTemperature };
        }

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