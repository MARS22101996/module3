using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Core.Services
{
    public class StringCalculator
    {
        private readonly char[] _defaultDelimeters = { ',', '\n' };
        private const string DelimeterIdentifier = "//";
        private const int DelimeterIdentifierOffset = 2;

        public long Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimeters = ExtractDelimeters(input);
            var numbersArray = ExtractNumbers(input, delimeters);

            return numbersArray.Sum();
        }

        private char[] ExtractDelimeters(string input)
        {
            var delimeters = _defaultDelimeters;

            if (input.StartsWith(DelimeterIdentifier))
            {
                delimeters = new[] { input[DelimeterIdentifier.Length] };
            }

            return delimeters;
        }

        private IEnumerable<long> ExtractNumbers(string input, char[] delimeters)
        {
            string numbersString = input;
            if (input.StartsWith(DelimeterIdentifier))
            {
                numbersString = input.Substring(
                    DelimeterIdentifier.Length + DelimeterIdentifierOffset);
            }

            return numbersString.Split(delimeters)
                    .Select(number => Convert.ToInt64(number));
        }
    }
}