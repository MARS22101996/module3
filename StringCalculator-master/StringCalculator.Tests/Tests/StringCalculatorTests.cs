
using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Returns_0_WhenInputStringIsEmpty()
        {
            var input = string.Empty;

            Check(input, 0);
        }

        [Test]
        [TestCase("0")]
        [TestCase("1")]
        public void Returns_InputNumber_WhenInputIsOneNumber(string input)
        {
            Check(input, Convert.ToInt32(input));
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("1,1", 2)]
        [TestCase("0,0", 0)]
        public void Returns_InputNumbersSum_WhenInputAreTwoNumbers(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [Test]
        [TestCase("1,2,3", 6)]
        [TestCase("1,1,1,1", 4)]       
        [TestCase("0", 0)]
        [TestCase("2,1001", 2)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [Test]
        [TestCase("1\n2\n3", 6)]
        [TestCase("1,2\n3", 6)]
        [TestCase("1\n1,1\n1", 4)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers_WithDelimeters(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [Test]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//$\n1$2$3", 6)]
        [TestCase("//\n\n1\n2\n3", 6)]
        public void Returns_InputNumbersSum_WhenInputAreSeveralNumbers_WithSpecifiedDelimeter(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [Test]
        [TestCase("2,1001", 2)]
        public void Returns_InputNumbersSum_NumbersBiggerThan1000(string input, long expectedResult)
        {
            Check(input, expectedResult);
        }

        [Test]
        public void Add_ParamHasNegativeNumbers_ExceptionThrownWithCorrectMessage()
        {
            var calculator = new Core.Services.StringCalculator();
            const string numbers = "-1, 10, -5, 3, -9, 11, 2, -3";

            Assert.Throws<Exception>(() => calculator.Add(numbers));
        }

        [Test]
        [TestCase("//[****]\n1****1****1****1****1****1****1****1", 8)]
        public void Add_ParamHasMulticharecterDelimeter_NumbersSplitedWithIt(string input, long expectedResult)
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