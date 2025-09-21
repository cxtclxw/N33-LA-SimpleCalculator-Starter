using System;
using SimpleCalculator.Properties;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public static double ConvertInputToNumeric(string argTextInput)
        {
            if (string.IsNullOrEmpty(argTextInput))
            { 
                throw new ArgumentException(Resources.InputNullOrEmpty);
            }

            if (int.TryParse(argTextInput, out int result))
            {
                return result;
            }
            else
            { 
                throw new ArgumentException(string.Format(Resources.InvalidNumberError, argTextInput)); 
            }
        }
    }
}
