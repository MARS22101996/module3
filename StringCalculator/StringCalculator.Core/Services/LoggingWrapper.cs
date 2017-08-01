using System;
using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{

    public class LoggingWrapper
    {
        private readonly IStringCalculator _calculator;
        private readonly ILogger _logger;
        private readonly IWebservice _service;

        public LoggingWrapper(IStringCalculator calculator, ILogger logger, IWebservice service)
        {
            _calculator = calculator;
            _logger = logger;
            _service = service;
        }

        public long Add(string numbersString)
        {
            var result = _calculator.Add(numbersString);

            try
            {
                _logger.Log($"The Add operation has successfully performed. Result : {result}");
            }
            catch (Exception ex)
            {
                _service.Notify($"Logging has failed with th exception message: {ex.Message}");
            }

            return result;
        }
    }
}
