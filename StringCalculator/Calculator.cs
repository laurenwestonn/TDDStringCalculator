using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            char[] delimiters = new char[] { ',', '\n' };
            string values = input;
            int sum = 0;

            // Check delimiters
            if (input[0] == '/' && input[1] == '/')
            { 
                string[] lines = input.Split('\n');
                var firstLine = lines[0];
                values = lines[1];

                char delimiter = firstLine.ToCharArray(2, 1)[0];
                delimiters = new char[] { delimiters[0], delimiters[1], delimiter };
            }

            string[] numbersString = values.Split(delimiters);


            List<int> numbers = numbersString
                .Select(n => int.Parse(n))
                .ToList();
            List<int> invalidNumbers = numbers.Where(n => n < 0).ToList();

            if (invalidNumbers.Any())
            {
                string invalidNumbersString = string.Join(',', invalidNumbers);
                string message = "Negatives not allowed: {0}";
                throw new ArgumentOutOfRangeException(string.Format(message, invalidNumbersString));
            }

            return numbers.Sum();
        }
    }

}
