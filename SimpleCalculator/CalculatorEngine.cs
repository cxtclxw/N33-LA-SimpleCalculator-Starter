using System;
using SimpleCalculator.Properties;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate (string argOperation, double argFirstNumber, double argSecondNumber)
        {
            double result = 0;
            bool operationValid = false;

            if (argOperation == "+" || argOperation.ToLower() == "add") {
                result = argFirstNumber + argSecondNumber;
                operationValid = true;
            }
            if (argOperation == "-" || argOperation.ToLower() == "subtract")
            {
                result = argFirstNumber - argSecondNumber;
                operationValid = true;
            }
            if (argOperation == "*" || argOperation.ToLower() == "multiply")
            {
                result = argFirstNumber * argSecondNumber;
                operationValid = true;
            }
            if (argOperation == "/" || argOperation.ToLower() == "divided by")
            {
                if (argSecondNumber == 0)
                {
                    throw new DivideByZeroException(Resources.DivideByZeroError);
                }
                result = argFirstNumber / argSecondNumber;
                operationValid = true;
            }

            if (!operationValid)
            {
                throw new ArgumentException(string.Format(Resources.InvalidOperationError, argOperation));
            }

                return result;
        }
        public double GetValidNumber(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                try
                {
                    return InputConverter.ConvertInputToNumeric(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine(Resources.InvalidNumberHelp);
                }
            }
        }

            private bool IsValidOperation(string operation)
        {
            if (operation == null) return false;

            string[] validOperations = { "+", "add", "-", "subtract", "*", "times", "/", "divided by" };
            foreach (var validOp in validOperations)
            {
                if (validOp == operation)
                {
                    return true;
                }
            }
            return false;
        }


        public string GetValidOperation()
        {
            Console.Write(Resources.OperationChoice);

            while (true)
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToLower().Trim();
                }
                if (IsValidOperation(input))
                {
                    return input;
                }

                Console.WriteLine(Resources.InvalidOperationError, input);
                Console.WriteLine(Resources.InvalidOperationHelp);
            }
        }
        private string GetOperationWord(string operation)
        {
            switch (operation)
            {
                case "+":
                case "add":
                    return "plus";
                case "-":
                case "subtract":
                    return "minus";
                case "*":
                case "times":
                    return "multiplied by";
                case "/":
                case "divided by":
                    return "divided by";
                default:
                    return operation; // fallback, should not reach
            }
        }

        public string FormatResult(string operation, double firstNumber, double secondNumber, double result)
        {
            string operationWord = GetOperationWord(operation);
            return $"The value {firstNumber:F2} {operationWord} the value {secondNumber:F2} is equal to {result:F2}.";
        }
    }
}
