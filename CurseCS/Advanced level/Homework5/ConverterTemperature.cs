using System;

namespace MyLibrary
{
    public static class ConverterTemperature
    {

        public static double CurrentFahrenheitValue { get; set; }
        public static double CurrentСelsiusValue { get; set; }

        public static void FromСelsiusToFahrenheit(double tC)
        {
            CurrentFahrenheitValue = (tC * 9 / 5) + 32; 
        }

        public static void FromFahrenheitToСelsius(double tF)
        {
            CurrentСelsiusValue = (tF - 32) * 5 / 9;
        }
        
    }
}

//(25 °C × 9 / 5) +32 = 77 °F
// - (100 °F − 32) × 5 / 9 = 37,778 °C