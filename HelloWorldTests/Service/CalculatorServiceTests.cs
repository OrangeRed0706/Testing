using HelloWorld.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTests.Service
{
    [TestClass]
    public class CalculatorTests
    {
        private CalculatorService? _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            // Given a new calculator
            _calculator = new CalculatorService();
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(-1, -2, -3)]
        [DataRow(100, 200, 300)]
        public void TestAddMethod(int a, int b, int expected)
        {
            // When adding two numbers
            var result = _calculator!.Add(a, b);

            // Then the result should be the sum of the two numbers
            Assert.AreEqual(expected, result, $"Expected the sum of {a} and {b} to be {expected}.");
        }

        [DataTestMethod]
        [DataRow(5, 3, 2)]
        [DataRow(10, 5, 5)]
        [DataRow(100, 50, 50)]
        public void TestSubtractMethod(int a, int b, int expected)
        {
            // When subtracting two numbers
            var result = _calculator!.Subtract(a, b);

            // Then the result should be the difference of the two numbers
            Assert.AreEqual(expected, result, $"Expected the difference of {a} and {b} to be {expected}.");
        }

        [DataTestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(-3, 3, -9)]
        [DataRow(100, 0, 0)]
        public void TestMultiplyMethod(int a, int b, int expected)
        {
            // When multiplying two numbers
            var result = _calculator!.Multiply(a, b);

            // Then the result should be the product of the two numbers
            Assert.AreEqual(expected, result, $"Expected the product of {a} and {b} to be {expected}.");
        }

        [DataTestMethod]
        [DataRow(10, 2, 5)]
        [DataRow(-9, -3, 3)]
        [DataRow(100, 1, 100)]
        public void TestDivideMethod(int a, int b, int expected)
        {
            // When dividing two numbers
            var result = _calculator!.Divide(a, b);

            // Then the result should be the quotient of the two numbers
            Assert.AreEqual(expected, result, $"Expected the quotient of {a} and {b} to be {expected}.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]

        public void TestDivideByZero()
        {
            // When dividing by zero
            _calculator!.Divide(5, 0);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _calculator = null;
        }
    }
}
