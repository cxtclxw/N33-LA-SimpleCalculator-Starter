using System;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate (string argOperation, double argFirstNumber, double argSecondNumber)
        {
            double result = 0;

            if (argOperation == "+" || argOperation.ToLower() == "add") {
                result = argFirstNumber + argSecondNumber;
            }

            return result;
        }
    }
}
