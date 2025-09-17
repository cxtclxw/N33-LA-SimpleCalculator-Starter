using System;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string argTextInput)
        {
            if (string.IsNullOrEmpty(argTextInput))
            { 
                throw new ArgumentException("Input cannot be null or empty");
            }

            if (double.TryParse(argTextInput, out double result))
            {
                return result;
            }
            else
            { 
                throw new ArgumentException($"Invalid input: '{argTextInput} is not a valid number."); 
            }
        }
    }
}
