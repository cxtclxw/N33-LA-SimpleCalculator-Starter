using System;

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

                double firstNumber = InputConverter.ConvertInputToNumeric(Console.ReadLine());
                double secondNumber = InputConverter.ConvertInputToNumeric(Console.ReadLine());
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                Console.WriteLine(result);

            } catch (Exception ex)
            {
                // Normally, we'd log this error to a file.
                Console.WriteLine(ex.Message);
            }

        }
    }
}
