using System;
using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    /// <summary>
    /// A <see cref="TankPressureSensorDecorator"/>-implementation, which differs the pressure calculation if the sensor's operating temperature are 
    /// within a minimum and a maximum value.
    /// </summary>
    public sealed class TemperatureTankPressureSensor : TankPressureSensorDecorator
    {
        private const double PRESSURE_INCREASE_FACTOR_IF_WITHIN_TEMPERATURE_OPERATING_WINDOW = 1.5;
        
        private readonly int _minimumDegreesCelsius;
        private readonly int _maxDegreesCelsius;

        public TemperatureTankPressureSensor(TankPressureSensorBase abstractTankPressureSensor, int minimumDegreesCelsius, int maxDegreesCelsius) : 
            base(abstractTankPressureSensor)
        {
            _minimumDegreesCelsius = minimumDegreesCelsius;
            _maxDegreesCelsius = maxDegreesCelsius;
        }

        public override double CalculatePressure(int waterIntakeVelocity)
        {
            Debug.WriteLine($"Called CalculatePressure() on {this.GetType().Name}");

            int currentOperatingTemperature = getCurrentOperatingTemperature();
            bool isOperatingTemperatureWithinWindow = IsOperatingTemperatureWithinWindow(currentOperatingTemperature);

            if (isOperatingTemperatureWithinWindow)
                return base.CalculatePressure(waterIntakeVelocity) * PRESSURE_INCREASE_FACTOR_IF_WITHIN_TEMPERATURE_OPERATING_WINDOW;
            else
                return base.CalculatePressure(waterIntakeVelocity);
        }

        private bool IsOperatingTemperatureWithinWindow(int operatingTemperature)
        {
            if (_maxDegreesCelsius >= operatingTemperature && operatingTemperature >= _minimumDegreesCelsius)
                return true;
            else
                return false;
        }

        private int getCurrentOperatingTemperature()
        {
            // simulate a reading of a temperature sensor
            Random rnd = new();
            int currentOperatingTemperature = rnd.Next(10, 30);
            return currentOperatingTemperature;
        }
    }
}