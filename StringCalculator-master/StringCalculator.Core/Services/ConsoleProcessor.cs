using System.Text.RegularExpressions;
using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class ConsoleProcessor : IConsoleProcessor
    {
        private readonly IConsoleInput _input;
        private readonly IConsoleOutput _output;
        private readonly IStringCalculator _calculator;
        private bool _isProcessing;

        public ConsoleProcessor(IConsoleInput input, IConsoleOutput output, IStringCalculator calculator)
        {
            _input = input;
            _output = output;
            _calculator = calculator;
            _isProcessing = true;
        }

        public void Process()
        {
            while (true)
            {
                var inputString = _input.Read();
                Process(inputString);

                if (_isProcessing)
                {
                    _output.Write("another input please");
                }
                else
                {
                    break;
                }
            }
        }

        private void Process(string input)
        {
            if (ProcessNoInput(input))
                return;

            ProcessAddCommandWithConsoleInput(input);
        }

        private bool ProcessNoInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                _isProcessing = false;
            }

            return !_isProcessing;
        }

        private void ProcessAddCommandWithConsoleInput(string input)
        {
            var addPattern = GetPattern("scalc ");
            var matches = Regex.Match(input, addPattern);

            if (matches.Success)
            {
                var numbers = input.Substring(6);
                ProcessAddCommand(numbers);
            }
        }

        public void ProcessAddCommand(string input)
        {
                var result = _calculator.Add(input);
                WriteCalculationResult(result);
        }

        private static string GetPattern(string prefix)
        {
            const string capture = @"[\d,]+";

            return $"{prefix}'({capture})'";
        }

        private void WriteCalculationResult(int result)
        {
            _output.Write($"Result of Add operation is {result}.");
        }
    }
}
