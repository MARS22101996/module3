using System;
using System.Collections.Generic;
using System.Linq;
using StringCalculator.Core.Interfaces;

namespace StringCalculator.Core.Services
{
    public class StringCalculator : IStringCalculator
    {
        private readonly string[] _defaultDelimeters = { ",", "\n" };
        private const string DelimeterIdentifier = "//";
        private const int DelimeterIdentifierOffset = 2;

        public long Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimeters = ExtractDelimeters(input);
            var numbersArray = ExtractNumbers(input, delimeters).ToList();

            CheckForNegativeNumbers(numbersArray);

            numbersArray = FilterNumbersGreaterThanAThousand(numbersArray);

            return numbersArray.Sum();
        }

        private string[] ExtractDelimeters(string input)
        {
            var delimeters = _defaultDelimeters;

            if (input.StartsWith(DelimeterIdentifier) && !input.Contains("["))
            {
                delimeters = new[] { input[DelimeterIdentifier.Length].ToString() };
            }
            if (input.StartsWith(DelimeterIdentifier) && input.Contains("["))
            {
                delimeters = input.Split('[', ']');
                var length = delimeters.Length;
                delimeters[length - 1] = _defaultDelimeters[0];
                delimeters[0] = _defaultDelimeters[0];
            }

            return delimeters;
        }

        private IEnumerable<long> ExtractNumbers(string input, string[] delimeters)
        {
            string numbersString = input;
            if (input.StartsWith(DelimeterIdentifier) && !input.Contains("["))
            {
                numbersString = input.Substring(
                    DelimeterIdentifier.Length + DelimeterIdentifierOffset);
            }
            if (input.StartsWith(DelimeterIdentifier) && input.Contains("["))
            {
                delimeters = input.Split('[', ']');
                var length = delimeters.Length;
                numbersString = delimeters[length - 1].Substring(1);
            }

            var i = numbersString.Split(delimeters, StringSplitOptions.None);

            return numbersString.Split(delimeters, StringSplitOptions.None)
                    .Select(number => Convert.ToInt64(number));
        }

        private static void CheckForNegativeNumbers(List<long> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                var exceptionMessage = $"negatives not allowed: {string.Join(", ", negativeNumbers)}";
                throw new Exception(exceptionMessage);
            }
        }

        private static List<long> FilterNumbersGreaterThanAThousand(List<long> numbers)
        {
            return numbers.Where(x => x <= 1000).ToList();
        }
    }
}