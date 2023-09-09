using System;
using System.Diagnostics;

namespace OpenClosed_DecoratorPattern.PressureSensorImplementations
{
    /// <summary>
    /// A tankpressuresensor decorater, which differs the pressure calculation if the sensor's operating temperature are within a minimum and a maximum value.
    /// </summary>
    public sealed class TemperatureTankPressureSensor : DecoratableTankPressureSensor
    {
        private readonly int _minimumDegreesCelcius;
        private readonly int _maxDegreesCelcius;
        private const double PRESSURE_INCREASE_FACTOR_IF_WITHIN_TEMPERATURE_OPERATING_WINDOW = 1.5;

        public TemperatureTankPressureSensor(AbstractTankPressureSensor abstractTankPressureSensor, int minimumDegreesCelcius, int maxDegreesCelcius) : base(abstractTankPressureSensor)
        {
            _minimumDegreesCelcius = minimumDegreesCelcius;
            _maxDegreesCelcius = maxDegreesCelcius;
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
            if (_maxDegreesCelcius >= operatingTemperature && operatingTemperature >= _minimumDegreesCelcius)
                return true;
            else
                return false;
        }

        private int getCurrentOperatingTemperature()
        {
            // simulate a reading off a temperature sensor
            Random rnd = new();
            int currentOperatingTemperature = rnd.Next(10, 30);
            return currentOperatingTemperature;
        }
    }
}