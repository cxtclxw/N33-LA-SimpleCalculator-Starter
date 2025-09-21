using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {

            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("add", number1, number2);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {

            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {

            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("subtract", number1, number2);
            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {

            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {

            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("multiply", number1, number2);
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {

            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {

            int number1 = 6;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("divided by", number1, number2);
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {

            int number1 = 6;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(3, result);

        }


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroErrorNonSymbol()
        {

            int number1 = 1;
            int number2 = 0;
            double result = _calculatorEngine.Calculate("divided by", number1, number2);

        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroErrorSymbol()
        {

            int number1 = 1;
            int number2 = 0;
            double result = _calculatorEngine.Calculate("/", number1, number2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidOperationThrowsArgumentException()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("invalid", number1, number2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullOperationThrowsArgumentException()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(null, number1, number2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyOperationThrowsArgumentException()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("", number1, number2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhitespaceOperationThrowsArgumentException()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("   ", number1, number2);
        }

        //EDGE CASES

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperationWithMixedCaseInvalidOperationThrowsException()
        {
            double number1 = 5.0;
            double number2 = 3.0;
            double result = _calculatorEngine.Calculate("InVaLiD", number1, number2);
        }

        [TestMethod]
        public void DivisionWithDecimalNumbersReturnsCorrectResult()
        {
            double number1 = 5.5;
            double number2 = 2.0;
            double result = _calculatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(2.75, result);
        }

        [TestMethod]
        public void MultiplicationWithDecimalNumbersReturnsCorrectResult()
        {
            double number1 = 2.5;
            double number2 = 4.0;
            double result = _calculatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(10.0, result);
        }

        [TestMethod]
        public void SubtractionWithNegativeNumbersReturnsCorrectResult()
        {
            double number1 = -5;
            double number2 = -3;
            double result = _calculatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void AdditionWithNegativeNumbersReturnsCorrectResult()
        {
            double number1 = -5;
            double number2 = -3;
            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        public void DivisionWithVerySmallNumbersReturnsCorrectResult()
        {
            double number1 = 0.0001;
            double number2 = 0.0001;
            double result = _calculatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void MultiplicationWithZeroReturnsZero()
        {
            double number1 = 5.0;
            double number2 = 0.0;
            double result = _calculatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void SubtractionResultingInZeroReturnsZero()
        {
            double number1 = 5.0;
            double number2 = 5.0;
            double result = _calculatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CaseInsensitivityUnit()
        {
            double number1 = 5.0;
            double number2 = 3.0;

            double result1 = _calculatorEngine.Calculate("ADD", number1, number2);
            double result2 = _calculatorEngine.Calculate("Add", number1, number2);
            double result3 = _calculatorEngine.Calculate("aDd", number1, number2);

            Assert.AreEqual(8.0, result1);
            Assert.AreEqual(8.0, result2);
            Assert.AreEqual(8.0, result3);
        }

    }
}
