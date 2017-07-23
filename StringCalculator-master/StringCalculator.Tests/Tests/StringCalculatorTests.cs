using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Returns_0_WhenInputStringIsEmpty()
        {
            var input = string.Empty;

            Check(input, 0);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("0")]
        [DataRow("-5")]
        public void Returns_InputNumber_WhenInputIsOneNumber(string input)
        {
            Check(input, Convert.ToInt32(input));
        }

        [TestMethod]
        [DataRow("1,2", 3)]
        [DataRow("1,1", 2)]
        [DataRow("10,-5", 5)]
        [DataRow("0,0", 0)]
        public void Returns_InputNumbersSum_WhenInputAreTwoNumbers(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [TestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("1,1,1,1", 4)]
        [DataRow("10,-5", 5)]
        [DataRow("0", 0)]
        [DataRow("1000000000,1000000000,1000000000", 3000000000)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [TestMethod]
        [DataRow("1\n2\n3", 6)]
        [DataRow("1,2\n3", 6)]
        [DataRow("1\n1,1\n1", 4)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers_WithDelimeters(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [TestMethod]
        [DataRow("//;\n1;2;3", 6)]
        [DataRow("//$\n1$2$3", 6)]
        [DataRow("//\n\n1\n2\n3", 6)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers_WithSpecifiedDelimeter(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        private void Check(string input, long expectedResult)
        {
            var calculator = new Core.Services.StringCalculator();
            var result = calculator.Add(input);

            Assert.AreEqual(expectedResult, result);
        }
    }
}