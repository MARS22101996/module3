using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests.Tests
{
    public class ConsoleProcessorTests
    {
        private ConsoleProcessor _sut;
        private Mock<IConsoleInput> _input;
        private Mock<IConsoleOutput> _output;
        private Mock<IStringCalculator> _calculator;


        [SetUp]
        public void SetUp()
        {
            _input = new Mock<IConsoleInput>();
            _output = new Mock<IConsoleOutput>();
            _calculator= new Mock<IStringCalculator>();
            _sut = new ConsoleProcessor(_input.Object, _output.Object, _calculator.Object);
        }

        [Test]
        public void Process_AddCalculation_ResultWrittenToOutput()
        {
            const string expected = "Result of Add operation is 10.";

            _calculator.Setup(calculator => calculator.Add(It.IsAny<string>())).Returns(10);

            _sut.ProcessAddCommand("5,5");

            _output.Verify(output => output.Write(expected), Times.Once);
        }

        [Test]
        public void Process_AddCalculationWithConsoleInput_ResultWrittenToOutput()
        {
            const string expected = "Result of Add operation is 10.";

            _calculator.Setup(calculator => calculator.Add(It.IsAny<string>())).Returns(10);

            _input.Setup(input => input.Read()).Returns("scalc '1,2,3,4'");

            //A.CallTo(() => input.Read()).ReturnsNextFromSequence("scalc'1,2,3,4'", "");

            _sut.Process();

            _output.Verify(output => output.Write(expected), Times.Once);
        }
    }
}
