using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalcTest
{
    [TestClass]
    public class CalculatorTests
    {
        private Class1 _calculator;

        /// <summary>
        /// Метод, выполняющийся перед каждым тестом
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _calculator = new Class1();
        }

        /// <summary>
        /// Метод, выполняющийся после каждого теста
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _calculator = null;
        }

        // ==================== ТЕСТЫ ДЛЯ СЛОЖЕНИЯ ====================

        [TestMethod]
        public void Add_PositiveNumbers_ReturnsSum()
        {
            // Arrange (подготовка)
            double a = 5;
            double b = 3;

            // Act (действие)
            double result = _calculator.Add(a, b);

            // Assert (проверка)
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ReturnsSum()
        {
            double result = _calculator.Add(-5, -3);
            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        public void Add_WithZero_ReturnsSameNumber()
        {
            double result = _calculator.Add(10, 0);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Add_DecimalNumbers_ReturnsSum()
        {
            double result = _calculator.Add(2.5, 3.7);
            Assert.AreEqual(6.2, result);
        }

        // ==================== ТЕСТЫ ДЛЯ ВЫЧИТАНИЯ ====================

        [TestMethod]
        public void Subtract_PositiveNumbers_ReturnsDifference()
        {
            double result = _calculator.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Subtract_NegativeNumbers_ReturnsDifference()
        {
            double result = _calculator.Subtract(-10, -4);
            Assert.AreEqual(-6, result);
        }

        [TestMethod]
        public void Subtract_WithZero_ReturnsSameNumber()
        {
            double result = _calculator.Subtract(10, 0);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Subtract_DecimalNumbers_ReturnsDifference()
        {
            double result = _calculator.Subtract(10.5, 3.2);
            Assert.AreEqual(7.3, result);
        }

        // ==================== ТЕСТЫ ДЛЯ УМНОЖЕНИЯ ====================

        [TestMethod]
        public void Multiply_PositiveNumbers_ReturnsProduct()
        {
            double result = _calculator.Multiply(6, 7);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Multiply_WithZero_ReturnsZero()
        {
            double result = _calculator.Multiply(100, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Multiply_NegativeNumbers_ReturnsProduct()
        {
            double result = _calculator.Multiply(-4, -5);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Multiply_PositiveAndNegative_ReturnsNegativeProduct()
        {
            double result = _calculator.Multiply(4, -5);
            Assert.AreEqual(-20, result);
        }

        [TestMethod]
        public void Multiply_DecimalNumbers_ReturnsProduct()
        {
            double result = _calculator.Multiply(2.5, 1.5);
            Assert.AreEqual(3.75, result);
        }

        // ==================== ТЕСТЫ ДЛЯ ДЕЛЕНИЯ ====================

        [TestMethod]
        public void Divide_PositiveNumbers_ReturnsQuotient()
        {
            double result = _calculator.Divide(15, 3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Divide_DecimalNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Divide(7, 2);
            Assert.AreEqual(3.5, result);
        }

        [TestMethod]
        public void Divide_NegativeNumbers_ReturnsQuotient()
        {
            double result = _calculator.Divide(-15, -3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Divide_PositiveByNegative_ReturnsNegativeQuotient()
        {
            double result = _calculator.Divide(15, -3);
            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            _calculator.Divide(10, 0);
        }

        // ==================== ТЕСТЫ ДЛЯ ВОЗВЕДЕНИЯ В СТЕПЕНЬ ====================

        [TestMethod]
        public void Power_IntegerExponent_ReturnsCorrectResult()
        {
            double result = _calculator.Power(2, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Power_ZeroExponent_ReturnsOne()
        {
            double result = _calculator.Power(5, 0);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Power_ZeroBase_ReturnsZero()
        {
            double result = _calculator.Power(0, 5);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Power_FractionalExponent_ReturnsRoot()
        {
            double result = _calculator.Power(9, 0.5);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Power_NegativeBaseIntegerExponent_ReturnsCorrectResult()
        {
            double result = _calculator.Power(-2, 3);
            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        public void Power_NegativeBaseEvenExponent_ReturnsPositiveResult()
        {
            double result = _calculator.Power(-2, 4);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_NegativeBaseFractionalExponent_ThrowsArgumentException()
        {
            _calculator.Power(-4, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_ZeroToZero_ThrowsArgumentException()
        {
            _calculator.Power(0, 0);
        }

        // ==================== КОМБИНИРОВАННЫЕ ТЕСТЫ ====================

        [TestMethod]
        public void ComplexOperation_AddThenMultiply_ReturnsCorrectResult()
        {
            // (5 + 3) * 2 = 16
            double result1 = _calculator.Add(5, 3);
            double result2 = _calculator.Multiply(result1, 2);
            Assert.AreEqual(16, result2);
        }

        [TestMethod]
        public void ComplexOperation_MultipleOperations_ReturnsCorrectResult()
        {
            // ((10 + 5) * 2) / 3 = 10
            double step1 = _calculator.Add(10, 5);
            double step2 = _calculator.Multiply(step1, 2);
            double result = _calculator.Divide(step2, 3);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ComplexOperation_WithPower_ReturnsCorrectResult()
        {
            // (2 + 3) ^ 2 = 25
            double sum = _calculator.Add(2, 3);
            double result = _calculator.Power(sum, 2);
            Assert.AreEqual(25, result);
        }

        // ==================== ТЕСТЫ НА ТОЧНОСТЬ ====================

        [TestMethod]
        public void Divide_WithPeriodicFraction_ReturnsCorrectPrecision()
        {
            double result = _calculator.Divide(1, 3);
            // Проверка с точностью до 10 знаков после запятой
            Assert.AreEqual(0.3333333333, result, 0.0000000001);
        }

        [TestMethod]
        public void Power_LargeNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Power(10, 5);
            Assert.AreEqual(100000, result);
        }
    }
}