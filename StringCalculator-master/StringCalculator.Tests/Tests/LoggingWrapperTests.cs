using System;
using Moq;
using NUnit.Framework;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;


namespace StringCalculator.Tests.Tests
{
    public class LoggingWrapperTests
    {
        private LoggingWrapper _sut;
        private Mock<ILogger> _logger;
        private Mock<IWebservice> _service;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            var calculator = new Mock<IStringCalculator>();
            _service = new Mock<IWebservice>();
            _sut = new LoggingWrapper(calculator.Object, _logger.Object, _service.Object);
        }

        [Test]
        public void Add_AnyParam_ResultLoggedWithCorrectMessage()
        {
            const string expectedLoggedMessage = "The Add operation has successfully performed. Result : 0";

            _sut.Add("1");

            _logger.Verify(logger => logger.Log(expectedLoggedMessage), Times.Once);
        }

        [Test]
        public void Add_LoggerThrownException_WebServiceIsNotifiedWithCorrectMessage()
        {
            const string expectedMessage = "Logging has failed with th exception message: " +
                                           "some exception message";

            _logger.Setup(logger => logger.Log(It.IsAny<string>())).Throws(new Exception("some exception message"));

            _sut.Add("1");

            _service.Verify(service => service.Notify(expectedMessage), Times.Once);
        }

    }
}
