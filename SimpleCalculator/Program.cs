using System;
using System.Runtime.CompilerServices;
using SimpleCalculator.Properties;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Class to perform actual calculations
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                double firstNumber = calculatorEngine.GetValidNumber(Resources.FirstNumber);
                double secondNumber = calculatorEngine.GetValidNumber(Resources.SecondNumber);
                string operation = calculatorEngine.GetValidOperation();

                //Calculate, display result
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                string resultMessage = calculatorEngine.FormatResult(operation, firstNumber, secondNumber, result);

                Console.WriteLine(resultMessage);
            } 
            
            catch (Exception ex)
            {
                // Normally, we'd log this error to a file.
                Console.WriteLine(ex.Message);
            }

        }
    }
}
