using FakeItEasy;
using NUnit.Framework;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;

namespace StringCalculator.Tests.Tests
{
    public class ConsoleProcessorTests
    {
        [Test]
        public void Process_AddCalculationWithConsoleInput_ResultWrittenToOutput()
        {
            const string expected = "Result of Add operation is 10.";
            var input = A.Fake<IConsoleInput>();
            var output = A.Fake<IConsoleOutput>();
            var calculator = A.Fake<IStringCalculator>();
            var sut = new ConsoleProcessor(input, output, calculator);
            A.CallTo(() => calculator.Add(A<string>._)).Returns(10);
            A.CallTo(() => input.Read()).ReturnsNextFromSequence("scalc '1,2,3,4'", "");

            sut.Process();

            A.CallTo(() => output.Write(expected))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Process_AddCalculationWithConsoleInput_AddWithRightParamsCalled()
        {
            const string expected = "'1,2,3,4'";
            var input = A.Fake<IConsoleInput>();
            var output = A.Fake<IConsoleOutput>();
            var calculator = A.Fake<IStringCalculator>();
            var sut = new ConsoleProcessor(input, output, calculator);
            A.CallTo(() => input.Read()).ReturnsNextFromSequence("scalc '1,2,3,4'", "");

            sut.Process();

            A.CallTo(() => calculator.Add(expected))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Process_EmptyInput_ProcessingInterrupted()
        {
            var input = A.Fake<IConsoleInput>();
            var output = A.Fake<IConsoleOutput>();
            var sut = new ConsoleProcessor(input,output, A.Fake<IStringCalculator>());
            A.CallTo(() => input.Read()).Returns("");

            sut.Process();

            A.CallTo(() => output.Write(A<string>._)).MustHaveHappened(Repeated.Never);
        }

        [Test]
        public void Process_InputSequence_CorrectMessageWritten()
        {
            const string expected = "another input please";
            var input = A.Fake<IConsoleInput>();
            var output = A.Fake<IConsoleOutput>();
            var sut = new ConsoleProcessor(input, output, A.Fake<IStringCalculator>());
            A.CallTo(() => input.Read()).ReturnsNextFromSequence("scalc '5,6,7'", "scalc '1,2,3,4'", "");

            sut.Process();

            A.CallTo(() => output.Write(expected))
                .MustHaveHappened(Repeated.Exactly.Twice);
        }
    }
}
